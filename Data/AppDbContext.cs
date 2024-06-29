using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var postsToSeed = new Post[6];

            for (int i = 1; i < 7; i++)
            {
                postsToSeed[i - 1] = new()
                {
                    Id = i,
                    Title = $"Post {i}",
                    Content = $"Content of post {i}",
                    Published = true
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
    }
}
