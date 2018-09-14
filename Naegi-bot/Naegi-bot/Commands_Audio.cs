using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using MakotoNaegi;
using YoutubeExtractor;

namespace NaegiCommands
{
    public class Commandments_Audio
    {
        //private VideoDownloader downloader;
        //private TaskCompletionSource<bool> DownloadFinishedEvent = new TaskCompletionSource<bool>();
        //private VideoInfo Videoinfo;

        // i. Connect -----------------------------------------------------------------------------
        [Command("join")]
        [Aliases("connect", "here")]
        [Description("Joins a voice channel.")]
        public async Task JoinVoice(CommandContext ctx, DiscordChannel channel = null)
        {
            string error_alreadyConnected = "It looks like I'm already connected to a voice channel in this Discord Server! Apologies... ;;";
            string error_nullVoiceChannel = "Are you in a voice channel? I'm not sure where to go... ;;";

            // Uses DSharpPlus VoiceNext extension.
            var voiceExtension = ctx.Client.GetVoiceNextClient();

            // Checks to see if it's connected to a voice channel already. If yes, throw exception.
            VoiceNextConnection connection = voiceExtension.GetConnection(ctx.Guild);
            if (connection != null) { await ctx.RespondAsync(error_alreadyConnected); }

            // Checks to see if channel to connect to is stated. If yes, connect. If not, check which channel member is in.
            // If member is not in a channel, throw exception. If they are, connect to that channel.
            if (channel == null)
            {
                channel = ctx.Member?.VoiceState?.Channel;

                if (channel == null) { await ctx.RespondAsync(error_nullVoiceChannel); }
                else { connection = await voiceExtension.ConnectAsync(channel); }
            }
            else { connection = await voiceExtension.ConnectAsync(channel); }
        }

        // ii. Leave -----------------------------------------------------------------------------
        [Command("leave")] [Aliases("exit")]
        [Description("Leaves a voice channel.")]
        public async Task LeaveVoice(CommandContext ctx)
        {
            string error_notConnected = "Oh -- sorry, but I don't think I'm there..? ;;";

            // Uses DSharpPlus VoiceNext extension.
            var voiceExtension = ctx.Client.GetVoiceNextClient();

            // Checks to see if it's connected to a voice channel already. If no, throw exception.
            VoiceNextConnection connection = voiceExtension.GetConnection(ctx.Guild);
            if (connection == null) { await ctx.RespondAsync(error_notConnected); }

            // Disconnects from existing channel connection.
            connection.Disconnect();
        }

        //// iii. Play -----------------------------------------------------------------------------
        //[Command("play")]
        //[Description("Plays a song!")]
        //public async Task PlaySong(CommandContext ctx, string url)
        //{
        //    string error_notConnected = "Oh -- sorry, but I don't think I'm there..? ;;";

        //    // Uses DSharpPlus VoiceNext extension.
        //    var voiceExtension = ctx.Client.GetVoiceNextClient();

        //    // Checks to see if it's connected to a voice channel already. If no, throw exception.
        //    var connection = voiceExtension.GetConnection(ctx.Guild);
        //    if (connection == null) { throw new InvalidOperationException(error_notConnected); }

        //    IEnumerable<VideoInfo> videoSource = DownloadUrlResolver.GetDownloadUrls(url);
        //    VideoInfo videoInfo = videoSource.First();
        //    if (videoInfo.RequiresDecryption) { DownloadUrlResolver.DecryptDownloadUrl(videoInfo); }
        //    string filePath = Path.Combine(Program.AudioCatcher, videoInfo.Title + videoInfo.AudioExtension);
        //    if (!File.Exists(filePath)) // downloads video if it isn't cached
        //    {
        //        #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        //        DownloadVideo(filePath);
        //        #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        //    }

        //    await connection.SendSpeakingAsync(true); // send a speaking indicator

        //    var psi = new ProcessStartInfo
        //    {
        //        FileName = "ffmpeg",
        //        Arguments = $@"-i ""{file}"" -ac 2 -f s16le -ar 48000 pipe:1",
        //        RedirectStandardOutput = true,
        //        UseShellExecute = false
        //    };
        //    var ffmpeg = Process.Start(psi);
        //    var ffout = ffmpeg.StandardOutput.BaseStream;

        //    var buff = new byte[3840];
        //    var br = 0;
        //    while ((br = ffout.Read(buff, 0, buff.Length)) > 0)
        //    {
        //        if (br < buff.Length) // not a full sample, mute the rest
        //            for (var i = br; i < buff.Length; i++)
        //                buff[i] = 0;

        //        await connection.SendAsync(buff, 20);
        //    }

        //    await connection.SendSpeakingAsync(false); // we're not speaking anymore
        //}

        //private async Task DownloadVideo(string filePath) //Downloads a Youtube Video
        //{
        //    downloader = new VideoDownloader(Videoinfo, filePath);
        //    downloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);
        //    try
        //    {
        //        downloader.Execute();
        //        DownloadFinishedEvent.SetResult(true);
        //    }
        //    catch (Exception DownloadException)
        //    {
        //        Console.WriteLine(DownloadException);
        //    }
        //    await DownloadFinishedEvent.Task;
        //}



        //var audioDownloader = new AudioDownloader(video,);

        //    // Register the progress events. We treat the download progress as 85% of the progress and the extraction progress only as 15% of the progress,
        //    // because the download will take much longer than the audio extraction.
        //    audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
        //    audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

        //    /* Execute the audio downloader.
        //     * For GUI applications note, that this method runs synchronously. */
        //    audioDownloader.Execute();
        //}
    }
}