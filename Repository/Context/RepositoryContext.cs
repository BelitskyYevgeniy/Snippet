using Microsoft.EntityFrameworkCore;
using Snippet.Data.Entities;

namespace Snippet.Data.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<PostEntity> Posts { get; set; }


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
            modelBuilder.Entity<UserEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PostEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LanguageEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TagEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            

            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<TagEntity>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<LanguageEntity>().HasIndex(u => u.Name).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}
