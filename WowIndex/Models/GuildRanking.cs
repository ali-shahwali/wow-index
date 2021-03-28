using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WowIndex.Models
{
    public class GuildRanking
    {

        [JsonProperty("guild")]
        public Guild guild { get; set; }

        [JsonProperty("faction")]
        public Faction faction { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("rank")]
        public long rank { get; set; }
    }

    public class Guild
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("realm")]
        public Realm realm { get; set; }
        
    }

    public class Realm
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("slug")]
        public string slug { get; set; }
    }

    public class Faction
    {

        [JsonProperty("type")]
        public string type { get; set; }
    }
}
