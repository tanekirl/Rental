using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;

namespace Rental.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly RentalCart _rentalCart;  // Додано поле для кошика

        public CarDetailsController(IAllCars carRepository, RentalCart rentalCart)
        {
            _carRepository = carRepository;
            _rentalCart = rentalCart;  // Ініціалізуємо поле кошика
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

            // Перевіряємо, чи є автомобіль у кошику
            var carInCart = _rentalCart.getRentalItems().Any(i => i.car.id == id);
            car.CarInCart = carInCart;

            return View(car);
        }
    }
}

