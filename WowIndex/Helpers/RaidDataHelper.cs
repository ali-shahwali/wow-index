﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Helpers
{
    public class RaidDataHelper
    {
        public static List<Models.RaidingLeaderboards.KillTimeCastleNathria> SortLeaderboard(List<Models.RaidingLeaderboards.KillTimeCastleNathria> Leaderboard)
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


        public static DateTime[] GetBossTimes(List<Models.POCO.CharacterAchievementPOCO.Achievement[]> raidTeam, int nrOfBosses)
        {
            DateTime[] bossKills = new DateTime[nrOfBosses];

            DateTime[] earliestKill = new DateTime[nrOfBosses];

            int j = 0;
            foreach (var member in raidTeam)
            {
                foreach (var achievement in member)
                {
                    // conversion to human datetime
                    string str = achievement.completed_timestamp.ToString();
                    str = str.Substring(0, str.Length - 3);
                    DateTime killTime = UnixTimeStampToDateTime(Convert.ToInt64(str)).ToUniversalTime();

                    if (killTime < earliestKill[j] || earliestKill[j] == new DateTime())
                    {
                        earliestKill[j] = killTime;
                        bossKills[j] = killTime;
                    }

                    j++;
                }
                j = 0;
            }

            return bossKills;
        }

        public static List<Models.RaidingLeaderboards.BossStats> ToBossStatsList(DateTime[] bossKills, string[] bossNames)
        {
            List<Models.RaidingLeaderboards.BossStats> stats = new List<Models.RaidingLeaderboards.BossStats>();
            for (int i = 0; i < 10; i++)
            {
                stats.Add(new Models.RaidingLeaderboards.BossStats
                {
                    Name = bossNames[i],
                    KillTime = bossKills[i]
                });
            }
            return stats;
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
