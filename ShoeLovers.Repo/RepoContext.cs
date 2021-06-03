using Microsoft.EntityFrameworkCore;
using ShoeLovers.Repo.Model;
using ShoeLovers.Repo.Repository;

namespace ShoeLovers.Repo
{
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions<RepoContext> options) : base(options) { }


        public DbSet<UserSelectionEntity> UserSelection { get; set; }
        public DbSet<ShoeSizeEntity> ShoeSize { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoeSizeEntity>()
                .HasKey(sse => new { sse.Id, sse.Size, sse.GenderId });

            modelBuilder.Entity<UserSelectionEntity>()
                .HasKey(use => new { use.UserId, use.ShoeSizeId });
        }
    }
}
