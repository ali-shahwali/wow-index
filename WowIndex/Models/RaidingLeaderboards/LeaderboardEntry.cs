using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public int RankWorld { get; set; }
        public int RankRealm { get; set; }
        public string GuildName { get; set; }
        public string GuildSlug { get; set; }
        public string Faction { get; set; }
        public string Realm { get; set; }
        public string RealmSlug { get; set; }
        public string Region { get; set; }
        public DateTime LatestProgressionTime { get; set; }
        public DateTime ExpirationTime { get; set; } = DateTime.Now.AddMinutes(15);
        public int Progression { get; set; }

    }
}
