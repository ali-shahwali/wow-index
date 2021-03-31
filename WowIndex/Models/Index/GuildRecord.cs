using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.Index
{
    public class GuildRecord
    {
        public int Id { get; set; }

        public DateTime age { get; set; }

        public string name { get; set; }

        public string region { get; set; }

        public string realm { get; set; }

        public string faction { get; set; }

        public long rank { get; set; }

        public int progress { get; set; }

        public long timestamp { get; set; }

        public string raidName { get; set; }
    }
}
