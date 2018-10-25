using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspnetCoreIdentityAndAuthentication.Models;

namespace AspnetCoreIdentityAndAuthentication.Data
{
    public class ApplicationDbContext 
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
             

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspnetCoreIdentityAndAuthentication.Models.CustomUser>().ToTable("dbo.User");
            base.OnModelCreating(modelBuilder);
        }
    }
}
