using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models
{
    public class GuildRanking
    {
        //    {
        //  "guild": {
        //    "name": "Honestly",
        //    "id": 41321785,
        //    "realm": {
        //      "name": "Frostmourne",
        //      "id": 3725,
        //      "slug": "frostmourne"
        //    }
        //  },
        //  "faction": {
        //    "type": "ALLIANCE"
        //  },
        //  "timestamp": 1538129132000,
        //  "region": "us",
        //  "rank": 2
        //} 

        public int Id { get; set; }
        public string Honestly { get; set; }
        public string RealmName { get; set; }
        public int RealmId { get; set; }
        public string RealmSlug { get; set; }
        public string Faciton { get; set; }
        public string timestamp { get; set; }
        public string region { get; set; }
        public int rank { get; set; }
    }
}
