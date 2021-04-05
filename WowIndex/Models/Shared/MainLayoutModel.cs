using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.Index
{
    public class MainLayoutModel
    {
        public string searchRegion { get; set; } = "eu";

        public string searchGuild { get; set; }

        public string searchRealm { get; set; }
    }
}
