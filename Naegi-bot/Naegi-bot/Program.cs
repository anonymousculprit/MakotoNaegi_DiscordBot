using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using Naegi_bot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MakotoNaegi {
    public class Program {
        static DiscordClient client;
        static CommandsNextModule commands;
        static VoiceNextClient voiceExtension;
        public static string AudioCatcher = "C:/Users/koakuma/Desktop/Desktop Icons/Desktop Eikons/Audio Catcher"; // Output folder for songs

        // REF: https://www.journaldev.com/12552/public-static-void-main-string-args-java-main-method
        // Main entry point for running programs. Set to start MainAsync. Await task to completion. Grabs result when done.
        static void Main(string[] args){
            var prog = new Program();
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args) {
            // Create new DiscordClient; configuration provided has Token, TokenType, and activates log prints to the command line.
            client = new DiscordClient(new DiscordConfiguration {
                Token = "////",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            // Create new Commands Module; configuration enables commands via Mentioning bot and when DM'd, Command prefix is @/.
            commands = client.UseCommandsNext(new CommandsNextConfiguration {
                EnableDms = true,
                EnableMentionPrefix = true,
                StringPrefix = "@/"
            });

            // Assign commands feed from Commandments + Commandments_Audio.
            commands.RegisterCommands<NaegiCommands.Commandments>();
            commands.RegisterCommands<NaegiCommands.Commandments_Audio>();

            // Activate Voice Next activation.
            voiceExtension = client.UseVoiceNext();

            // Set the TimerCallback that will be used
            TimerCallback tcb = CheckReminders;

            // Start a timer that checks reminders every minute 60000 ms
            Timer reminderChecker = new Timer(tcb, null, 0, 60000);

            // Connects Client with Discord. Blocks off MainAsync until program is closed.
            await client.ConnectAsync();
            await Task.Delay(-1);
        }

        // Possible improvement: deserialise each time the file is changed to save processing
        // Store on the bot instance - fetch list on start and on file change
        static async void CheckReminders(object stateInfo) {
            // Read the JSON file maintaining the list of reminders
            // Deserialise into a list of objects
            // Check each one against Time.Now or something
            // If the data is less than the current time then send the reminder and remove the object from the list
            // Serialise the list into JSON and write it to file (if any reminders were made)

            // bool to track if any reminders were made
            bool isReminded = false;

            // For storing potential changes
            JObject changed;
            List<Reminder> toRemove = new List<Reminder>();
            
            // Use file stream
            using (StreamReader reader = File.OpenText(@"..\..\Reminders.json"))
            {
                // Read file stream
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                JArray reminderArray = (JArray)o["Reminders"];

                // Convert to list of Reminder objects
                List<Reminder> reminders = reminderArray.Select(r => new Reminder
                {
                    Time = (DateTime)r["Time"],
                    Content = (string)r["Content"],
                    Mentions = (string)r["Mentions"],
                    ChannelID = (ulong)r["ChannelID"]
                }).ToList();

                foreach (Reminder r in reminders)
                {
                    // Check if each Reminder has already passed
                    if (r.Time < DateTime.Now)
                    {
                        // If it has, send the reminder message and ping the relevant parties

                        // Construct the full message
                        string msg = $"Hey{r.Mentions}, remember to {r.Content}!";

                        // Get the channel where the reminder was made
                        DiscordChannel channel = await client.GetChannelAsync(r.ChannelID);

                        // Send the msg
                        await channel.SendMessageAsync(msg);

                        // Remove the reminder from list
                        toRemove.Add(r);

                        // Let the function know that a reminder has been completed
                        isReminded = true;
                    }
                }

                // Remove from list first
                foreach(var r in toRemove)
                {
                    reminders.Remove(r);
                }

                // Add to list on dto
                ReminderDTO dto = new ReminderDTO();
                dto.Reminders.AddRange(reminders);
                changed = JObject.FromObject(dto);
            }

            // If a reminder was made, the file needs to be updated, otherwise can be skipped
            if (isReminded)
            {
                File.WriteAllText(@"..\..\Reminders.json", changed.ToString());
            }
        }
    }
}