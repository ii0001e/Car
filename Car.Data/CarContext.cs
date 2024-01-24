using Car.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<CarData> CarSet { get; set; }

    }

}
