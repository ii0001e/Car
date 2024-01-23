using Car.Core.Dto;
using Car.Core.Domain;

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
