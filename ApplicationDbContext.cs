using LinkedInAppProject.Authentication;
using LinkedInAppProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> UserProfile { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplier> JobAppliers { get; set; }

    }
}
