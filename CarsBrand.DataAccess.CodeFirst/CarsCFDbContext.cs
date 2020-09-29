using CarsBrand.DataAccess.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsBrand.DataAccess.CodeFirst
{
    public class CarsCFDbContext : DbContext
    {
        private const string defaultConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarsCfDB.mdf;Integrated Security=True;MultipleActiveResultSets=True";

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }

        public CarsCFDbContext()
            : base()
        {
            Database.EnsureCreated();
        }

        public CarsCFDbContext(DbContextOptions<CarsCFDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(defaultConnStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand bmw = new Brand()
            {
                Id = 1,
                Name = "BMW"
            };

            Brand audi = new Brand()
            {
                Id = 2,
                Name = "Audi"
            };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW 510" };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "Audi A3" };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A4" };

            modelBuilder.Entity<Car>(car =>
            {
                car.HasOne(c => c.Brand)
                   .WithMany(b => b.Cars)
                   .HasForeignKey(c => c.BrandId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Brand>().HasData(bmw, audi);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, audi1, audi2);
        }
    }
}
