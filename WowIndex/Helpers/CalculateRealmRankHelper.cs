using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowIndex.Data;
using WowIndex.Models.RaidingLeaderboards;

namespace WowIndex.Helpers
{
    public class CalculateRealmRankHelper
    {
        public static int RealmRank(Models.GuildObjects.Guild guild, List<Models.RaidingLeaderboards.KillTimeCastleNathria> Leaderboard, List<Models.GuildObjects.Guild> Guilds)
        {

            // realm lb
            var realmLeaderboard = new List<KillTimeCastleNathria>();
            foreach (var item in Leaderboard)
            {
                var guildRealm = Guilds.Where(x => x.Id == item.GuildId).FirstOrDefault().RealmSlug;
                if (guildRealm == guild.RealmSlug)
                    realmLeaderboard.Add(item);
            }

            var LeaderboardSorted = Helpers.RaidDataHelper.SortLeaderboard(realmLeaderboard);

            // get ranking for the current guild
            var y = LeaderboardSorted.FindIndex(x => x.GuildId == guild.Id) + 1;
            return y;
        }
    }
}
