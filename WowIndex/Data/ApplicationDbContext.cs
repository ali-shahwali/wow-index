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
        

        public DbSet<Models.Index.GuildRecord> Records { get; set; }

        public DbSet<Models.UserProfile.Character> Characters { get; set; }

        public DbSet<Models.UserProfile.Profile> Profiles { get; set; }

        public DbSet<Token> Tokens { get; set; }





        // Store all guilds in a table
        public DbSet<Models.Guild> Guilds { get; set; }


        // To reduce load on requests each raid will have its own table (we dont have to filter one huge table)
        public DbSet<Models.RaidingLeaderboards.LeaderboardCastleNathria> LeaderboardCastleNathria { get; set; }

    }
}
