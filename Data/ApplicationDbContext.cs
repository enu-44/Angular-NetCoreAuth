using auth_angular.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auth_angular.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser> 
{
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<JobSeeker> JobSeekers { get; set; }
    }
}