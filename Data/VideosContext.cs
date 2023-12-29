using System.Collections.Generic;
using dotnet_videos_review_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.PostgreSQL
{
    public class VideosContext : DbContext
    {
        public VideosContext(DbContextOptions<VideosContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=dotnet_videos;Username=root;Password=root"
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().Property(f => f.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Video> Videos { get; set; }
    }
}
