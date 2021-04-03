using System;

namespace WowIndex.Models.RaidingLeaderboards
{
    public class LeaderboardCastleNathria
    {
        public int Id { get; set; }

        public int GuildId { get; set; }

        public int Progress { get; set; }

        public DateTime RecordCreationDate { get; set; }

        public string Boss1KillTime { get; set; }
        public string Boss2KillTime { get; set; }
        public string Boss3KillTime { get; set; }
        public string Boss4KillTime { get; set; }
        public string Boss5KillTime { get; set; }
        public string Boss6KillTime { get; set; }
        public string Boss7KillTime { get; set; }
        public string Boss8KillTime { get; set; }
        public string Boss9KillTime { get; set; }
        public string Boss10KillTime { get; set; }
    }
}
