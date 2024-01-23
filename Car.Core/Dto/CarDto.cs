namespace Car.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string BodyType { get; set; }
        public int BuildingYear { get; set; }
        public int EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int? MaxSpeed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Modifieted { get; set; }
    }
}
