using System;
using System.Collections.Generic;

namespace WowIndex.Helpers
{
    public class RaidDataHelper
    {
        
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
