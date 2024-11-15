using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;

namespace Rental.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        // Дія для списку автомобілів
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category, string sortOrder)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            // Сортування автомобілів за ціною
            switch (sortOrder)
            {
                case "price_asc":
                    cars = _allCars.Cars.OrderBy(i => i.price); // від дешевих до дорогих
                    break;
                case "price_desc":
                    cars = _allCars.Cars.OrderByDescending(i => i.price); // від дорогих до дешевих
                    break;
                default:
                    cars = _allCars.Cars.OrderBy(i => i.id); // за замовчуванням
                    break;
            }

            if (!string.IsNullOrEmpty(category))
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Електро")).OrderBy(i => i.id);
                    currCategory = "Електро";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Класика")).OrderBy(i => i.id);
                    currCategory = "Класика";
                }
            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory
            };

            ViewBag.Title = "Сторінка з авто";

            return View(carObj);
        }

        // Дія для умов оренди
        [Route("Cars/Conditions")]
        public IActionResult Conditions()
        {
            ViewBag.Title = "Умови оренди";
            return View();
        }

        // Дія для сторінки "Про нас"
        [Route("Cars/About")]
        public IActionResult About()
        {
            ViewBag.Title = "Про нас";
            return View();
        }

        // Дія для політики конфіденційності
        [Route("Cars/Politic")]
        public IActionResult Politic()
        {
            ViewBag.Title = "Політика конфіденційності";
            return View();
        }
    }
}
