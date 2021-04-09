using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Data
{
    public class SiteDiagnostic
    {
        public int Id { get; set; }

        public int RegisteredAccounts { get; set; }

        public int RegisteredProfiles { get; set; }

        public int RegisteredGuilds { get; set; }

        public int GuildsWithProgression { get; set; }
        public int GuildsWithFullClear { get; set; }

        // in days
        public double AverageProgressionTime { get; set; }

        public string MostDifficultBoss { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
