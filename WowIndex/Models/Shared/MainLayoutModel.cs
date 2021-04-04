using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.Index
{
    public class MainLayoutModel
    {
        public string searchRegion { get; set; } = "eu";

        public string SearchGuild { get; set; }

        public string SearchGuildRealm { get; set; }
    }
}
