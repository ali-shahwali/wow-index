using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WowIndex.Models.Index
{
    public class LeaderboardEntries
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
}
