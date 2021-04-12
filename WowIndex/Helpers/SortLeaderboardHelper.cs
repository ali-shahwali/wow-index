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
            // delete outdated records
            if (LeaderboardEntries.Count > 0)
            {
                _context.RankedCastleNathriaLeaderboard.RemoveRange(LeaderboardEntries);
                _context.SaveChanges();
            }

            // build up a sorted leaderboard
            var Leaderboard = _context.KillTimeCastleNathria.ToList();
            var LeaderboardSorted = Helpers.RaidDataHelper.SortLeaderboard(Leaderboard);

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
    }
}
