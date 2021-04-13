using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class LeaderboardModel
    {
        public LeaderboardEntry Guild { get; set; }
        public int Rank { get; set; }
    }
}
