using Car.Core.Domain;
using Car.Core.Dto;
using Car.Core.ServiceInterface;
using Car.Data;
using Microsoft.EntityFrameworkCore;

namespace Car.ApplicationServices.Services
{
    public class CarDataServices : ICarDataServices
    {

            private readonly CarContext _context;

            public CarDataServices
                (
                    CarContext context
                )
            {
                _context = context;
            }

            public async Task<CarData> Create(CarDataDto dto)
            {
                CarData car = new CarData();

                car.Id = Guid.NewGuid();
                car.Brand = dto.Brand;
                car.Mark = dto.Mark;
                car.BodyType = dto.BodyType;
                car.BuildingYear = dto.BuildingYear;
                car.EngineCapacity = dto.EngineCapacity;
                car.FuelType = dto.FuelType;
                car.EnginePower = dto.EnginePower;
                car.CreatedAt = DateTime.Now;
                car.Modifieted = DateTime.Now;

                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();



            return car;
            }
            public async Task<CarData> Update(CarDataDto dto)
            {
                var domain = new CarData();
                {
                    domain.Id = Guid.NewGuid();
                    domain.Brand = dto.Brand;
                    domain.Mark = dto.Mark;
                    domain.BodyType = dto.BodyType;
                    domain.BuildingYear = dto.BuildingYear;
                    domain.EngineCapacity = dto.EngineCapacity;
                    domain.FuelType = dto.FuelType;
                    domain.EnginePower = dto.EnginePower;
                    domain.CreatedAt = DateTime.Now;
                    domain.Modifieted = DateTime.Now;



                    _context.Cars.Update(domain);
                    await _context.SaveChangesAsync();


                    return domain;



                }


            }

            public async Task<CarData> Delete(Guid id)
            {
                var CarDataId = await _context.Cars
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Cars.Remove(CarDataId);
                await _context.SaveChangesAsync();

                return CarDataId;
            }



            public async Task<CarData> GetAsync(Guid id)
            {
                var result = await _context.Cars
                    .FirstOrDefaultAsync(x => x.Id == id);

                return result;
            }
        }
}

