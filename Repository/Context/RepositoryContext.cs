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
            modelBuilder.Entity<UserEntity>().HasKey(e => e.Id).HasName("PrimaryKey_UserId");
            modelBuilder.Entity<TagEntity>().HasKey(e => e.Id).HasName("PrimaryKey_TagId");
            modelBuilder.Entity<LanguageEntity>().HasKey(e => e.Id).HasName("PrimaryKey_LanguageId");
            modelBuilder.Entity<PostEntity>().HasKey(e => e.Id).HasName("PrimaryKey_PostId");
            modelBuilder.Entity<LikeEntity>().HasKey(e => e.Id).HasName("PrimaryKey_LikeId");
            modelBuilder.Entity<PostTagEntity>().HasKey(e => new { e.PostId, e.TagId });
            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserEntity>()
                 .HasMany(e => e.Likes)
                 .WithOne(e => e.User)
                 .HasForeignKey(e => e.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.User)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostEntity>()
               .HasOne(e => e.Language)
               .WithMany(e => e.Posts)
               .HasForeignKey(e => e.LanguageId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostEntity>()
                .HasMany(e => e.PostTags)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                /*.OnDelete(DeleteBehavior.Cascade)*/;

            modelBuilder.Entity<PostEntity>()
                .HasMany(e => e.Likes)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostEntity>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikeEntity>()
                .HasOne(e => e.User)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LikeEntity>()
               .HasOne(e => e.Post)
               .WithMany(e => e.Likes)
               .HasForeignKey(e => e.PostId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CommentEntity>()
               .HasOne(e => e.User)
               .WithMany(e => e.Comments)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentEntity>()
               .HasOne(e => e.Post)
               .WithMany(e => e.Comments)
               .HasForeignKey(e => e.PostId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TagEntity>()
                .HasMany(e => e.PostTags)
                .WithOne(e => e.Tag)
                .HasForeignKey(e => e.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTagEntity>()
                .HasOne(e => e.Post)
                .WithMany(e => e.PostTags)
                .HasForeignKey(e => e.PostId);

            modelBuilder.Entity<PostTagEntity>()
                .HasOne(e => e.Tag)
                .WithMany(e => e.PostTags)
                .HasForeignKey(e => e.TagId);

            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.AuthId).IsUnique();
            modelBuilder.Entity<TagEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<LanguageEntity>().HasIndex(u => u.Name).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}
