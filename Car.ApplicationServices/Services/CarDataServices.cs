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

            await _context.CarSet.AddAsync(car);
            await _context.SaveChangesAsync();



            return car;
        }
        public async Task<CarData> Update(CarDataDto dto)
        {
            var existingCarData = await _context.CarSet
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (existingCarData != null)
            {
                existingCarData.Brand = dto.Brand;
                existingCarData.Mark = dto.Mark;
                existingCarData.BodyType = dto.BodyType;
                existingCarData.BuildingYear = dto.BuildingYear;
                existingCarData.EngineCapacity = dto.EngineCapacity;
                existingCarData.FuelType = dto.FuelType;
                existingCarData.EnginePower = dto.EnginePower;
                existingCarData.Modifieted = DateTime.Now;

                await _context.SaveChangesAsync();
            }

            return existingCarData;
        }



        public async Task<CarData> Delete(Guid id)
        {
            var carData = await _context.CarSet.FirstOrDefaultAsync(x => x.Id == id);

            if (carData != null)
            {
                _context.CarSet.Remove(carData);
                await _context.SaveChangesAsync();
            }

            return carData;
        }



        public async Task<CarData> GetAsync(Guid id)
        {
            var result = await _context.CarSet
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}

