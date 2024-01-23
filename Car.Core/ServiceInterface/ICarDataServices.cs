using Car.Core.Domain;
using Car.Core.Dto;

namespace Car.Core.ServiceInterface
{
    public interface ICarDataServices
    {
        Task<CarData> Create(CarDataDto dto);
        Task<CarData> GetAsync(Guid id);

        Task<CarData> Update(CarDataDto dto);

        Task<CarData> Delete(Guid id);
    }
}
