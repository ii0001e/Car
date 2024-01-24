using Car.Core.Dto;
using Car.Core.ServiceInterface;
using Car.Data;
using Car.Core.CarData;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    public class CarDataController : Controller
    {
        private readonly CarContext _context;
        private readonly ICarDataServices _carDataServices;



        public CarDataController
           (
               CarContext context,
               ICarDataServices carDataServices
               )
        {
            _context = context;
            _carDataServices = carDataServices;
        }


        public IActionResult Index()
        {
            var result = _context.CarSet
                .Select(x => new CarDataIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Mark = x.Mark,
                    BodyType = x.BodyType,
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CarDataCreateUpdateViewModel kindergarten = new CarDataCreateUpdateViewModel();

            return View("CreateUpdate", kindergarten);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarDataCreateUpdateViewModel vm)
        {
            var dto = new CarDataDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Mark = vm.Mark,
                BodyType = vm.BodyType,
                EngineCapacity = vm.EngineCapacity,
                EnginePower = vm.EnginePower,
                FuelType = vm.FuelType,
                BuildingYear = vm.BuildingYear,


            };

            var result = await _carDataServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index), vm);
            //return index

        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var cardata = await _carDataServices.GetAsync(id);

            if (cardata == null)
            {
                return NotFound();

            }

            var vm = new CarDataDetailsViewModel();

            vm.Id = cardata.Id;
            vm.Brand = cardata.Brand;
            vm.Mark = cardata.Mark;
            vm.BodyType = cardata.BodyType;
            vm.EngineCapacity = cardata.EngineCapacity;
            vm.EnginePower = cardata.EnginePower;
            vm.FuelType = cardata.FuelType;
            vm.BuildingYear = cardata.BuildingYear;

            return View(vm);



        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cardata = await _carDataServices.GetAsync(id);

            if (cardata == null)
            {
                return NotFound();
            }


            var vm = new CarDataCreateUpdateViewModel();

            vm.Id = cardata.Id;
            vm.Brand = cardata.Brand;
            vm.Mark = cardata.Mark;
            vm.BodyType = cardata.BodyType;
            vm.EngineCapacity = cardata.EngineCapacity;
            vm.EnginePower = cardata.EnginePower;
            vm.FuelType = cardata.FuelType;
            vm.BuildingYear = cardata.BuildingYear;
            vm.CreatedAt = cardata.CreatedAt;
            vm.Modifieted = cardata.Modifieted;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarDataCreateUpdateViewModel vm)
        {
            var dto = new CarDataDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Mark = vm.Mark,
                BodyType = vm.BodyType,
                EngineCapacity = vm.EngineCapacity,
                EnginePower = vm.EnginePower,
                FuelType = vm.FuelType,
                BuildingYear = vm.BuildingYear,
                CreatedAt = vm.CreatedAt,
                Modifieted = DateTime.Now,
            };
            var result = await _carDataServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index), vm);

            }
            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cardata = await _carDataServices.GetAsync(id);
            if (cardata == null)
            {
                return NotFound();
            }
            var vm = new CarDataDeleteViewModel();

            vm.Id = cardata.Id;
            vm.Brand = cardata.Brand;
            vm.Mark = cardata.Mark;
            vm.BodyType = cardata.BodyType;
            vm.EngineCapacity = cardata.EngineCapacity;
            vm.EnginePower = cardata.EnginePower;
            vm.FuelType = cardata.FuelType;
            vm.BuildingYear = cardata.BuildingYear;
            vm.CreatedAt = cardata.CreatedAt;
            vm.Modifieted = cardata.Modifieted;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var cardataid = await _carDataServices.Delete(id);

            if (cardataid == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
