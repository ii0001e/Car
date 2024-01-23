using Car.CarTest;
using Car.Core.Domain;
using Car.Core.Dto;
using Car.Core.ServiceInterface;

namespace Shop.CarDataTest
{
    public class CarDataTest1 : TestBase
    {
        [Fact]
        public async Task ShouldNotAddEmptyCarDataWhenReturnResult()
        {
            CarDataDto dto = new CarDataDto();

            dto.Brand = "TestCar";
            dto.Mark = "SomeCar";
            dto.BodyType = "SaloonVagon";
            dto.BuildingYear = 2022;
            dto.EngineCapacity = 1996;
            dto.FuelType = "Diesel";
            dto.EnginePower = 180;
            dto.CreatedAt = DateTime.Now;
            dto.Modifieted = DateTime.Now;


            var result = await Svc<ICarDataServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]

        public async Task ShouldGetByIDCarData()
        {
            Guid guid = Guid.Parse("b92b6647-5b31-4fc3-85d6-f8d9cded2455");
            Guid guid1 = Guid.Parse("b92b6647-5b31-4fc3-85d6-f8d9cded2455"); ;

            //Act
            await Svc<ICarDataServices>().GetAsync(guid);
            Assert.Equal(guid, guid1);


        }


        [Fact]
        public async Task ShouldDeleteByIdCarDataWhenDeleteCarData()
        {

            CarDataDto carData = MockCarData();

            var AddCar = await Svc<ICarDataServices>().Create(carData);

            var result = await Svc<ICarDataServices>().Delete((Guid)AddCar.Id);


            Assert.Equal(result, AddCar);


        }

        [Fact]
        public async Task ShouldDeletebyIdWhenDidNotDeleteCarData()
        {
            CarDataDto carData = MockCarData();

            var AddCar = await Svc<ICarDataServices>().Create(carData);

            var AddCar2 = await Svc<ICarDataServices>().Create(carData);

            var result = await Svc<ICarDataServices>().Delete((Guid)AddCar2.Id);


            Assert.NotEqual(result.Id, AddCar.Id);


        }

        [Fact]
        public async Task ShouldUodateCarData_WhenUpdateData()
        {
            var guid = new Guid("8a6113ed-5f97-4758-a91f-5857b8b25a4c");

            CarData carData = new CarData();
            CarDataDto dto = MockCarData();

            carData.Id = Guid.Parse("8a6113ed-5f97-4758-a91f-5857b8b25a4c");
            carData.Brand = "TestCar1";
            carData.Mark = "SomeCar1";
            carData.BodyType = "SaloonVagonSaloon";
            carData.BuildingYear = 2022;
            carData.EngineCapacity = 2994;
            carData.FuelType = "Gasoline";
            carData.EnginePower = 190;
            carData.CreatedAt = DateTime.Now;
            carData.Modifieted = DateTime.Now;
            //Act
            await Svc<ICarDataServices>().Update(dto);
            Assert.Equal(carData.Id, guid);
            Assert.Equal(carData.BuildingYear, dto.BuildingYear);
            Assert.NotEqual(carData.Brand, dto.Brand);
            Assert.NotEqual(carData.Mark, dto.Mark);
            Assert.DoesNotMatch(carData.FuelType, dto.FuelType);
        }

        [Fact]
        public async Task ShouldUpdateCarData_WhenNotUpdatedata()
        {
            CarDataDto dto = MockCarData();
            await Svc<ICarDataServices>().Create(dto);
            CarDataDto nullUpdate = MockZeroCarData();
            await Svc<ICarDataServices>().Update(nullUpdate);
            var NullId = nullUpdate.Id;
            Assert.True(dto.Id == NullId);
        }

        private CarDataDto MockZeroCarData()
        {
            CarDataDto nullDto = new()
            {
                Id = null,
                Brand = "TestCar",
                Mark = "SomeCar",
                BodyType = "SaloonVagon",
                BuildingYear = 2022,
                EngineCapacity = 1996,
                FuelType = "Diesel",
                EnginePower = 180,
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,
            };
            return nullDto;
        }

        private CarDataDto MockCarData()
        {
            CarDataDto carData = new()
            {
                Brand = "TestCar",
                Mark = "SomeCar",
                BodyType = "SaloonVagon",
                BuildingYear = 2022,
                EngineCapacity = 1996,
                FuelType = "Diesel",
                EnginePower = 180,
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,
            };

            return carData;
        }

        private CarDataDto MockUpdateCarDataData()
        {
            CarDataDto update = new()
            {
                Brand = "TestCar1",
                Mark = "SomeCar",
                BodyType = "SaloonVagon",
                BuildingYear = 2022,
                EngineCapacity = 2096,
                FuelType = "Diesel",
                EnginePower = 180,
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,
            };
            return update;
        }
    }
}
