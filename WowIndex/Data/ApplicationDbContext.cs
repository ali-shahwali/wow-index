using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WowIndex.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        public DbSet<WowIndex.Models.Index.GuildRecord> Records { get; set; }

        public DbSet<WowIndex.Models.UserProfile.Character> Characters { get; set; }

        public DbSet<WowIndex.Models.UserProfile.Profile> Profiles { get; set; }

    }
}
