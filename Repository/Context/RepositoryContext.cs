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
            /*modelBuilder.Entity<UserEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PostEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LanguageEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TagEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LikeEntity>().Property(e => e.Id).ValueGeneratedOnAdd();*/

            modelBuilder.Entity<UserEntity>().HasKey(e => e.Id).HasName("PrimaryKey_UserId");
            modelBuilder.Entity<TagEntity>().HasKey(e => e.Id).HasName("PrimaryKey_TagId");
            modelBuilder.Entity<LanguageEntity>().HasKey(e => e.Id).HasName("PrimaryKey_LanguageId");
            modelBuilder.Entity<PostEntity>().HasKey(e => e.Id).HasName("PrimaryKey_PostId");
            modelBuilder.Entity<LikeEntity>().HasKey(e => e.Id).HasName("PrimaryKey_LikeId");

            /*modelBuilder.Entity<LikeEntity>()
           .HasOne(e => e.User)
           .WithMany(e => e.Likes)
           .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<LikeEntity>()
           .HasOne(e => e.Post)
           .WithMany(e => e.Likes)
           .HasForeignKey(e => e.PostId);*/

            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<TagEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<LanguageEntity>().HasIndex(u => u.Name).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}
