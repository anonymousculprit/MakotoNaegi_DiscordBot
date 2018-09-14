using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naegi_bot {
    class Reminder {
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string Mentions { get; set; }
        public ulong ChannelID { get; set; }

        public Reminder(DateTime time, string content, string mentions, ulong channel) {
            Time = time;
            Content = content;
            Mentions = mentions;
            ChannelID = channel;
        }

        public Reminder()
        {

        }
    }
}
