using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public GuildObjects.Guild Guild { get; set; }
        public int Score { get; set; }
        public DateTime LatestProgressionTime { get; set; }
        public int Progression { get; set; }

    }
}
