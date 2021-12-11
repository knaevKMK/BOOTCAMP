namespace Git.Data
{
    using Git.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity=> {
                entity.HasMany(u => u.Repositories)
                    .WithOne(r => r.Owner).HasForeignKey(r => r.OwnerId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(u => u.Commits)
                .WithOne(c => c.Creator).HasForeignKey(c => c.CreatorId).OnDelete(DeleteBehavior.Restrict);
            });
                
            modelBuilder.Entity<Repository>()
                .HasMany(e=>e.Commits)
                .WithOne(c=>c.Repository)
                .HasForeignKey(c=>c.RepositoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Commit>();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Git;Integrated Security=true;");
            }
        }
    }
}