using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowIndex.Data;
using WowIndex.Models.RaidingLeaderboards;

namespace WowIndex.Helpers
{
    public class CalculateRealmRank
    {
        public static int LeaderboardEntries { get; set; }

        public static int RealmRank(Models.GuildObjects.Guild guild, ApplicationDbContext _context)
        {
            // world lb
            var Leaderboard = _context.KillTimeCastleNathria.ToList();

            // realm lb
            var realmLeaderboard = new List<KillTimeCastleNathria>();
            foreach (var item in Leaderboard)
            {
                var guildRealm = _context.Guilds.Where(x => x.Id == item.GuildId).FirstOrDefault().RealmSlug;
                if (guildRealm == guild.RealmSlug)
                {
                    realmLeaderboard.Add(item);
                }
            }

            var LeaderboardSorted = new List<KillTimeCastleNathria>();

            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 10).OrderBy(x => x.Boss10KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 9).OrderBy(x => x.Boss9KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 8).OrderBy(x => x.Boss8KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 7).OrderBy(x => x.Boss7KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 6).OrderBy(x => x.Boss6KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 5).OrderBy(x => x.Boss5KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 4).OrderBy(x => x.Boss4KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 3).OrderBy(x => x.Boss3KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 2).OrderBy(x => x.Boss2KillTime));
            LeaderboardSorted.AddRange(realmLeaderboard.Where(x => x.Progress == 1).OrderBy(x => x.Boss1KillTime));

            // get ranking for the current guild
            var y = LeaderboardSorted.FindIndex(x => x.GuildId == guild.Id) + 1;
            return y;
        }
    }
}
