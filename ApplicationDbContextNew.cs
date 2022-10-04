using LinkedInAppProject.Authentication;
using LinkedInAppProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkedInAppProject
{
    public class ApplicationDbContextNew : IdentityDbContext<ApplicationUserNew>
    {
        public ApplicationDbContextNew(DbContextOptions<ApplicationDbContextNew> options) : base(options)
        { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> UserProfile { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplier> JobAppliers { get; set; }
        public DbSet<JobApplier> SingleUser { get; set; }
    }
}
