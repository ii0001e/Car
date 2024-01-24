using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Car.Core.Domain
{
    public class CarData
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Brand { get; set; }
        public string? Mark { get; set; }
        [DisplayName("Body")]
        public string? BodyType { get; set; }
        [DisplayName("Building Year")]
        public int BuildingYear { get; set; }
        [DisplayName("Engine Capacity")]
        public int EngineCapacity { get; set; }
        [DisplayName("Fuel Type")]
        public string? FuelType { get; set; }
        [DisplayName("Engine Power in kW")]
        public int EnginePower { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Created at")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Modified at")]
        public DateTime Modifieted { get; set; }

    }
}
