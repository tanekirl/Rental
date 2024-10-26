using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental.Data;
using Rental.Data.interfaces;
using Rental.Data.Models;

namespace Rental.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAllOrders allorders;
        private readonly RentalCart rentalCart;

        public OrderController(IAllOrders allorders, RentalCart rentalCart)
        {
            this.allorders = allorders;
            this.rentalCart = rentalCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            rentalCart.listRentalItems = rentalCart.getRentalItems();

            if (rentalCart.listRentalItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваш кошик пустий");
            }

            if (ModelState.IsValid)
            {
                allorders.createOrder(order);
                return RedirectToAction("Complete"); // Це правильно
            }



            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Оренда була успішно оброблена";
            return View();
        }



    }
}