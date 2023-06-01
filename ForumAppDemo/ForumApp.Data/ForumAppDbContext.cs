using ForumApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        { }

        private Post FirstPost { get; set; } = null!;
        private Post SecondPost { get; set; } = null!;
        private Post ThirdPost { get; set; } = null!;

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();
            modelBuilder
                .Entity<Post>()
                .HasData(FirstPost, SecondPost, ThirdPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPosts()
        {
            FirstPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "My first post",
                Text = "Ipsum dolor sit amet, consectetur adipiscing elit. Curabitur tincidunt velit vehicula vulputate congue. Donec feugiat pharetra ipsum, vel egestas nisi ultrices sed. Phasellus posuere vestibulum metus "
            };

            SecondPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "My second post",
                Text = "Aenean quis lacus imperdiet, ultrices lectus at, volutpat arcu. Aliquam erat volutpat. Donec quis condimentum libero. Quisque non ma"
            };

            ThirdPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "My third post",
                Text = "Nunc sed metus ullamcorper magna accumsan vestibulum non ut tellus. Aenean porttitor imperdiet augue, at facilisis nisi elementum id"
            };
        }
    }
}
