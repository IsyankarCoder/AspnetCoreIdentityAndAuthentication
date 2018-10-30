using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace AspnetCoreIdentityAndAuthentication.Data
{
    public partial class ApplicationDbContext
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

            Database.Migrate();
        }

        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> IdentityUserRoles { get; set; }
        public DbSet<Microsoft.AspNetCore.Identity.IdentityRole<string>> IdentityRoles { get; set; }
        public DbSet<Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>> IdentityRoleClaims { get; set; }

        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>> IdentityUserLogins { get; set; }

        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserToken<string>> IdentityUserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AspnetCoreIdentityAndAuthentication.Models.CustomUser>().ToTable("dbo.User");

            modelBuilder.Entity<AspnetCoreIdentityAndAuthentication.Models.CustomUser>()
                .HasIndex(d => new { d.Email, d.UserName }).HasName("QueryAndSort");

            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(d => new { d.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(g => new { g.UserId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(h => new { h.UserId });
            modelBuilder.Entity<IdentityRole<string>>().HasKey(d => new { d.Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
