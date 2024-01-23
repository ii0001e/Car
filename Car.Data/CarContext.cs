using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Car.Core.Domain;

namespace Car.Data
{
    public class CarContext
    {
        public CarContext
            (
             DbContextOptions<CarContext> options
        ) : base(options) { }

        public DbSet<Car> Cars { get; set; }

    }
}
