using Microsoft.EntityFrameworkCore;
using Snippet.Data.Entities;

namespace Snippet.Data.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<LikeEntity> Likes { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<PostTagEntity> PostTags { get; set; }


        public RepositoryContext()
        {
            Database.EnsureCreated();
        }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostTagEntity>().HasKey(e => new { e.PostId, e.TagId });
            

            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<TagEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<LanguageEntity>().HasIndex(u => u.Name).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}
