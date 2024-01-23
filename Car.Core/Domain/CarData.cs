using System.ComponentModel.DataAnnotations;

namespace Car.Core.Domain
{
    public class CarData
    {
        [Key]
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string BodyType { get; set; }
        public int BuildingYear { get; set; }
        public int EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int EnginePower { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Modifieted { get; set; }
    }
}
