using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace NaegiCommands
{
    public class Commandments
    {
        // i. Ping! --------------------------------------------------------------------------------------
        [Command("ping")]
        [Description("Checks for connectivity. Ping!")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.RespondAsync($"Pong!");
        }

        // ii. Hello! --------------------------------------------------------------------------------------
        [Command("hi")]
        [Aliases("hello", "hey")]
        [Description("Say hello to Naegi!")]
        public async Task Hello_1(CommandContext ctx)
        {
            string i = $"Hello, {ctx.User.Mention}! I hope you're having a good day today!";
            string ii = $"Hello, {ctx.User.Mention}! I hope things are going well for you today!";
            string iii = $"Hello, {ctx.User.Mention}! It's nice to see you again!";

            string[] lines = new string[] { i, ii, iii };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // iii. I love you! --------------------------------------------------------------------------------------
        [Command("iloveyou")]
        [Aliases("ily")]
        [Description("Declare your love to Naegi!")]
        public async Task Aishiteru_1(CommandContext ctx)
        {
            string i = $"I love you too, {ctx.User.Mention}! Thank you for appreciating me every day! ~<3";
            string ii = $"Ah, thank you, {ctx.User.Mention}! I love you too! I hope you're taking care of yourself today! ~<3 ";
            string iii = $"Oh, thank you, {ctx.User.Mention}! I love and appreciate you and your support every day! ~<3";

            string[] lines = new string[] { i, ii, iii };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // iv. Dice Roll --------------------------------------------------------------------------------------
        [Command("roll")]
        [Description("Roll a dice. Format as 'xdy', where x is number of dice, while y is number of sides on dice. e.g. 5d20")]
        public async Task Dice(CommandContext ctx, string dice)
        {
            var rnd = new Random();

            string[] split = dice.Split('d');

            int[] number = Array.ConvertAll<string, int>(split, int.Parse);

            int amountOfDice = (int)number[0];
            int sidesOfDice = (int)number[1];
            int total = 0;

            for (int i = 0; i < amountOfDice; i++)
            {
                total += rnd.Next(1, sidesOfDice + 1);
            }

            await ctx.RespondAsync($"Rolling a " + dice + "... Your roll is " + total + "!");
        }

        // v. Cheer! --------------------------------------------------------------------------------------
        [Command("cheer")]
        [Aliases("imsad", "naegi", "naegi!")]
        [Description("Let Naegi cheer you up!")]
        public async Task Cheer_1(CommandContext ctx, DiscordMember member = null)
        {
            string i = "";
            string ii = "";
            string iii = "";
            string iv = "";
            string v = "";
            string vi = "";
            string vii = "";
            string viii = "";
            string ix = "";
            string x = "";

            if (member == null)
            {
                i = $"You can make it through today, {ctx.User.Mention}! I believe in you!";
                ii = $"You're amazing, {ctx.User.Mention}! There's nothing you can't do!";
                iii = $"You're doing great, {ctx.User.Mention}! Please, keep up what you're doing!";
                iv = $"Don't give up, {ctx.User.Mention}! Not as long as there's hope!";
                v = $"{ctx.User.Mention}, let's keep moving forward, together!";
                vi = $"{ctx.User.Mention}! I'm cheering you on, so please keep at it! You can do it!";
                vii = $"Let's do what we can, {ctx.User.Mention}! Together! You have my support!";
                viii = $"Don't give up hope, {ctx.User.Mention}! Let's keep at it!";
                ix = $"I'll be at your side, {ctx.User.Mention}, so please don't give up! Let's work at it together!";
                x = $"Have hope, {ctx.User.Mention}, I know you can do it! I'm sure of it!";
            }

            else if (member != null)
            {
                i = $"You can make it through today, {member.Mention}! I believe in you!";
                ii = $"You're amazing, {member.Mention}! There's nothing you can't do!";
                iii = $"You're doing great, {member.Mention}! Please, keep up what you're doing!";
                iv = $"Don't give up, {member.Mention}! Not as long as there's hope!";
                v = $"{member.Mention}, let's keep moving forward, together!";
                vi = $"{member.Mention}! I'm cheering you on, so please keep at it! You can do it!";
                vii = $"Let's do what we can, {member.Mention}! Together! You have my support!";
                viii = $"Don't give up hope, {member.Mention}! Let's keep at it!";
                ix = $"I'll be at your side, {member.Mention}, so please don't give up! Let's work at it together!";
                x = $"Have hope, {member.Mention}, I know you can do it! I'm sure of it!";
            }

            string[] lines = new string[] { i, ii, iii, iv, v, vi, vii, viii, ix, x };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // vi. Kiss~ --------------------------------------------------------------------------------------

        [Command("kiss")]
        [Description("Give a kiss to Naegi!")]
        public async Task Kiss_1(CommandContext ctx)
        {
            string i = $"A-ah--, t-thank you, {ctx.User.Mention}! ///";
            string ii = $"O-oh, thank you, {ctx.User.Mention}... I-I love you too! ///";
            string iii = $"...♡!! T-thank you, {ctx.User.Mention}! ///";
            string iv = $"I-I love you too, {ctx.User.Mention}! H-here, have a kiss from me too...♡! ///";
            string v = $"O-oh, I appreciate it, {ctx.User.Mention}... T-Thank you for loving me, too...♡ ///";

            string[] lines = new string[] { i, ii, iii, iv, v };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // vii. Hug! --------------------------------------------------------------------------------------

        [Command("hug")]
        [Description("Hug Naegi today!")]
        public async Task Hug_1(CommandContext ctx)
        {
            string i = $"Haha! T-Thank you, {ctx.User.Mention}. ♡~";
            string ii = $"You sure are warm, {ctx.User.Mention}... T-Thank you! ♡~";
            string iii = $"T-Thank you, {ctx.User.Mention}. Have a hug from me too! ♡~";
            string iv = $"O-oh, I appreciate the hug, {ctx.User.Mention}. Thank you! ♡~";
            string v = $"{ctx.User.Mention}, thank you for the hug...! /// ♡~ ";

            string[] lines = new string[] { i, ii, iii, iv, v };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // viii. Good Morning! --------------------------------------------------------------------------------------

        [Command("goodmorning")]
        [Aliases("goodmorningnaegi", "goodmorning!", "goodmorningnaegi!")]
        [Description("Start today with a good morning from Naegi!")]
        public async Task Morning(CommandContext ctx, DiscordMember member = null)
        {
            string i = "";
            string ii = "";
            string iii = "";

            if (member == null)
            {
                i = $"Good morning, {ctx.User.Mention}! Let's have a great day today! 🌱";
                ii = $"Good morning, {ctx.User.Mention}! I hope you had a nice rest last night! ✨";
                iii = $"Good morning, {ctx.User.Mention}! Let's do our best today! 💪 ";

            }

            else if (member != null)
            {
                i = $"Good morning, {member.Mention}! Let's have a great day today! 🌱";
                ii = $"Good morning, {member.Mention}! I hope you had a nice rest last night! ✨";
                iii = $"Good morning, {member.Mention}! Let's do our best today! 💪 ";
            }

            string[] lines = new string[] { i, ii, iii };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // ix. Good Night! --------------------------------------------------------------------------------------

        [Command("goodnight")]
        [Aliases("goodnightnaegi", "goodnight!", "goodnightnaegi!")]
        [Description("Head off to bed with a blessing from our lord and saviour!")]
        public async Task Night(CommandContext ctx, DiscordMember member = null)
        {
            string i = "";
            string ii = "";
            string iii = "";
            string iv = "";

            if (member == null)
            {
                i = $"Good night, {ctx.User.Mention}! I hope you dream of nice things tonight! ミ★";
                ii = $"Good night, {ctx.User.Mention}! I hope you're able to rest well! 💤";
                iii = $"Good night, {ctx.User.Mention}! Let's do our best tomorrow! 🌙 ";
                iv = $"Good night, {ctx.User.Mention}! Don't worry, I'll be here when you get up! ✨";
            }

            else if (member != null)
            {
                i = $"Good night, {member.Mention}! I hope you dream of nice things tonight! ミ★";
                ii = $"Good night, {member.Mention}! I hope you're able to rest well! 💤";
                iii = $"Good night, {member.Mention}! Let's do our best tomorrow! 🌙 ";
                iv = $"Good night, {member.Mention}! Don't worry, I'll be here when you get up! ✨";
            }

            string[] lines = new string[] { i, ii, iii, iv };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

        // x. Praise --------------------------------------------------------------------------------------

        [Command("praise")]
        [Aliases("bless", "thankyou", "cheerfor")]
        [Description("Deliver Naegi's blessing onto someone else!")]
        public async Task Praise(CommandContext ctx, DiscordMember member)
        {
            string i = $"You did great today, {member.Mention}! I'm so proud of you!";
            string ii = $"Congratulations, {member.Mention}! I knew you could do it!";
            string iii = $"Good job, {member.Mention}! Way to go!";
            string iv = $"Great work, {member.Mention}! Please, keep up what you're doing!";

            string[] lines = new string[] { i, ii, iii, iv };

            var rnd = new Random();
            int number = rnd.Next(0, lines.Length);

            await ctx.RespondAsync(lines[number]);
        }

    }
}