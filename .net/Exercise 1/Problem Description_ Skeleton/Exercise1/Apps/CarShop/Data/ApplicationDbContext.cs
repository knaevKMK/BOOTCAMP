
namespace CarShop.Data
{
    using CarShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Issue> Issues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarShop;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Issue>();
            modelBuilder.Entity<Car>().HasMany(x=>x.Issues)
                .WithOne(x=>x.Car).HasForeignKey(x=>x.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Car>().HasOne(x => x.Owner)
            //    .WithMany(x => x.Cars).HasForeignKey(x => x.OwnerId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
