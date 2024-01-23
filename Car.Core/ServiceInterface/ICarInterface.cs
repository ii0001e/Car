using Car.Core.Dto;

namespace Car.Core.ServiceInterface
{
    public class ICarInterface
    {
        Task<Car> Create(CarDto dto);
        Task<Car> GetAsync(Guid id);

        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);
    }
}
