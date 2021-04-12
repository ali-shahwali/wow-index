using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowIndex.Data;
using WowIndex.Models.RaidingLeaderboards;

namespace WowIndex.Helpers
{
    public class SortLeaderboardHelper
    {
        public static void SortLeaderboard(ApplicationDbContext _context, List<LeaderboardEntry> LeaderboardEntries, List<Models.GuildObjects.Guild> Guilds)
        {

            _context.RankedCastleNathriaLeaderboard.RemoveRange(LeaderboardEntries);
            _context.SaveChanges();

            // build up a sorted leaderboard
            var Leaderboard = _context.KillTimeCastleNathria.ToList();
            var LeaderboardSorted = Sort(Leaderboard);

            int rankWorld = 1;
            foreach (var item in LeaderboardSorted)
            {
                var guild = Guilds.Where(x => x.Id == item.GuildId).FirstOrDefault();
                int RealmRank = Helpers.CalculateRealmRankHelper.RealmRank(guild, Leaderboard, Guilds);
                DateTime killTime = new DateTime();
                DateTime[] bossTimes = Helpers.CastleNathriaKillTimeHelper.GetKillTimes(item);
                foreach (var time in bossTimes)
                {
                    if (time != new DateTime())
                    {
                        killTime = time;
                        break;
                    }
                }

                // build entry to display in list on page
                LeaderboardEntry entry = new LeaderboardEntry
                {
                    RankWorld = rankWorld,
                    RankRealm = RealmRank,
                    LatestProgressionTime = killTime,
                    GuildName = guild.Name,
                    Faction = guild.FactionName,
                    Realm = guild.Realm,
                    Region = guild.Region,
                    Progression = item.Progress,
                    GuildSlug = guild.NameSlug,
                    RealmSlug = guild.RealmSlug
                };

                LeaderboardEntries.Add(entry);

                // add this new soted list to the db
                _context.RankedCastleNathriaLeaderboard.Add(entry);
                rankWorld++;
            }

            _context.SaveChanges();
        }

        public static List<Models.RaidingLeaderboards.KillTimeCastleNathria> Sort(List<Models.RaidingLeaderboards.KillTimeCastleNathria> Leaderboard)
        {
            var LeaderboardSorted = new List<Models.RaidingLeaderboards.KillTimeCastleNathria>();

            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 10).OrderBy(x => x.Boss10KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 9).OrderBy(x => x.Boss9KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 8).OrderBy(x => x.Boss8KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 7).OrderBy(x => x.Boss7KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 6).OrderBy(x => x.Boss6KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 5).OrderBy(x => x.Boss5KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 4).OrderBy(x => x.Boss4KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 3).OrderBy(x => x.Boss3KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 2).OrderBy(x => x.Boss2KillTime));
            LeaderboardSorted.AddRange(Leaderboard.Where(x => x.Progress == 1).OrderBy(x => x.Boss1KillTime));

            return LeaderboardSorted;
        }
    }
}
