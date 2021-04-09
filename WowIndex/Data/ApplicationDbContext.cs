using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WowIndex.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        public DbSet<Models.RaidingLeaderboards.HallOfFameRecord> HoFRecords { get; set; }

        public DbSet<Models.UserProfile.Character> Characters { get; set; }

        public DbSet<Models.UserProfile.Profile> Profiles { get; set; }

        public DbSet<Token> Tokens { get; set; }

        public DbSet<Models.GuildObjects.Guild> Guilds { get; set; }

        public DbSet<Models.RaidingLeaderboards.KillTimeCastleNathria> KillTimeCastleNathria { get; set; }

        public DbSet<Models.RaidingLeaderboards.LeaderboardEntry> RankedCastleNathriaLeaderboard { get; set; }

        public DbSet<Models.GuildObjects.GuildRoster> GuildRoster { get; set; }

        public DbSet<SiteDiagnostic> SiteDiagnostics { get; set; }

        public DbSet<Models.BugReport> BugReports { get; set; }

    }
}
