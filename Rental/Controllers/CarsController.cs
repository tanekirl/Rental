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

        // для списку авто
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category, string sortOrder)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            // Сорт ціна
            switch (sortOrder)
            {
                case "price_asc":
                    cars = _allCars.Cars.OrderBy(i => i.price); // менше - більше
                    break;
                case "price_desc":
                    cars = _allCars.Cars.OrderByDescending(i => i.price); // більше - менше
                    break;
                default:
                    cars = _allCars.Cars.OrderBy(i => i.id); //деф
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

        //умови
        [Route("Cars/Conditions")]
        public IActionResult Conditions()
        {
            ViewBag.Title = "Умови оренди";
            return View();
        }

        //ебаут
        [Route("Cars/About")]
        public IActionResult About()
        {
            ViewBag.Title = "Про нас";
            return View();
        }

        //політікс
        [Route("Cars/Politic")]
        public IActionResult Politic()
        {
            ViewBag.Title = "Політика конфіденційності";
            return View();
        }
    }
}
