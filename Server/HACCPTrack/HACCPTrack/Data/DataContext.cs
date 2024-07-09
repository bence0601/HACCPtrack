using HACCPTrack.Models;
using HACCPTrack.Models.Invites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HACCPTrack.Data
{
    public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private readonly IConfiguration _configuration;

        public DbSet<Invite> Invites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CheckItem> CheckItems { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DataBaseConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Restaurant relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Restaurant)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RestaurantId);

            // Restaurant - CreatedBy relationship
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull, depending on your requirements

            // Restaurant - Log relationship
            modelBuilder.Entity<Log>()
                .HasOne(l => l.Restaurant)
                .WithMany(r => r.Logs)
                .HasForeignKey(l => l.RestaurantId);

            // Log - CheckItem relationship
            modelBuilder.Entity<CheckItem>()
                .HasOne(ci => ci.Log)
                .WithMany(l => l.CheckItems)
                .HasForeignKey(ci => ci.LogId);

            // User - Log relationship
            modelBuilder.Entity<Log>()
                .HasOne(l => l.CreatedByUser)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull, depending on your requirements


        }



    }
}