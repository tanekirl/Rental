using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;

namespace Rental.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly IAllCars _carRepository;

        public CarDetailsController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult Index(int id)
        {
            var car = _carRepository.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            // Якщо у автомобіля немає зображень, додаємо основне зображення
            if (car.Images == null || !car.Images.Any())
            {
                car.Images = new List<CarImage>
                {
                    new CarImage { Url = car.img } // Використовуємо основне зображення
                };
            }

            return View(car);
        }
    }
}
