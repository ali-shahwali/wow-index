using System;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class BossStats
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public DateTime KillTime { get; set; }
    }
}
