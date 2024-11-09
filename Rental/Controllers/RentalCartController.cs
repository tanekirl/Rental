using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental.Data.interfaces;
using Rental.Data.Models;
using Rental.ViewModels;

namespace Rental.Controllers
{
    [Authorize]
    public class RentalCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly RentalCart _rentalCart;
        public RentalCartController(IAllCars carRep, RentalCart rentalCart)
        {
            _carRep = carRep;
            _rentalCart = rentalCart;

        }

        public ViewResult Index()
        {
            var items = _rentalCart.getRentalItems();
            _rentalCart.listRentalItems = items;

            var obj = new RentalCartViewModel
            {
                rentalCart = _rentalCart,
                TotalPrice = _rentalCart.GetTotalPrice() // Додаємо загальну ціну
            };

            return View(obj);
        }



        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _rentalCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult removeFromCart(int id)
        {
            _rentalCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}