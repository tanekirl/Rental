using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;

namespace Rental.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly RentalCart _rentalCart;  

        public CarDetailsController(IAllCars carRepository, RentalCart rentalCart)
        {
            _carRepository = carRepository;
            _rentalCart = rentalCart; 
        }

        public IActionResult Index(int id)
        {
            var car = _carRepository.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            
            if (car.Images == null || !car.Images.Any())
            {
                car.Images = new List<CarImage>
            {
                new CarImage { Url = car.img } 
            };
            }

            var carInCart = _rentalCart.getRentalItems().Any(i => i.car.id == id);
            car.CarInCart = carInCart;

            return View(car);
        }
    }
}

