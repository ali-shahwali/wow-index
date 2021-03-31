using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WowIndex.Models.Index
{
    public class LeaderboardEntriesPOCO
    {

        [JsonProperty("_links")]
        public Links _links { get; set; }

        [JsonProperty("slug")]
        public string slug { get; set; }

        [JsonProperty("criteria_type")]
        public string criteria_type { get; set; }

        [JsonProperty("entries")]
        public GuildRanking[] entries { get; set; }

        [JsonProperty("journal_instance")]
        public JournalInstance JournalInstance { get; set; }
    }

    public class JournalInstance
    {
        [JsonProperty("key")]
        public Self Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class Links
    {

        [JsonProperty("self")]
        public Self self { get; set; }
    }

    public class Self
    {

        [JsonProperty("href")]
        public string href { get; set; }
    }

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
