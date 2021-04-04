using System;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class LeaderboardCastleNathria
    {
        public int Id { get; set; }

        public int GuildId { get; set; }

        public int Progress { get; set; }

        public DateTime RecordCreationDate { get; set; }

        public DateTime Boss1KillTime { get; set; }
        public DateTime Boss2KillTime { get; set; }
        public DateTime Boss3KillTime { get; set; }
        public DateTime Boss4KillTime { get; set; }
        public DateTime Boss5KillTime { get; set; }
        public DateTime Boss6KillTime { get; set; }
        public DateTime Boss7KillTime { get; set; }
        public DateTime Boss8KillTime { get; set; }
        public DateTime Boss9KillTime { get; set; }
        public DateTime Boss10KillTime { get; set; }
    }
}
