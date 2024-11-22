using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;
using System.Linq;

namespace Rental.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            // Фільтруємо улюблені машини, які також доступні
            var favCars = _carRep.getFavCars.Where(c => c.available).ToList();

            var homeCars = new HomeViewModel
            {
                favCars = favCars // Передаємо тільки відфільтровані машини
            };

            return View(homeCars);
        }
    }
}
