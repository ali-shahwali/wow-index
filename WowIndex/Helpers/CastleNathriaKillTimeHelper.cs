using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Helpers
{
    public class CastleNathriaKillTimeHelper
    {
        public static DateTime[] GetKillTimes(Models.RaidingLeaderboards.KillTimeCastleNathria raidProgRecord)
        {
            return new DateTime[] 
            { 
                raidProgRecord.Boss10KillTime,
                raidProgRecord.Boss9KillTime,
                raidProgRecord.Boss8KillTime,
                raidProgRecord.Boss7KillTime,
                raidProgRecord.Boss6KillTime,
                raidProgRecord.Boss5KillTime,
                raidProgRecord.Boss4KillTime,
                raidProgRecord.Boss3KillTime,
                raidProgRecord.Boss2KillTime,
                raidProgRecord.Boss1KillTime
            };
        }
    }
}
