using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental.Data;
using Rental.Data.interfaces;
using Rental.Data.Models;
using System.Linq;

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

        // GET: Order/Checkout
        public IActionResult Checkout()
        {
            
            rentalCart.listRentalItems = rentalCart.getRentalItems();

         
            if (rentalCart.listRentalItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваш кошик пустий");
            }

           
            var orderDetails = rentalCart.listRentalItems.Select(item => new OrderDetail
            {
                car = item.car,  //item.Car != null
                price = item.car?.price ?? 0  //
            }).ToList();

            
            var order = new Order
            {
                orderDetails = orderDetails,
                RentalStart = DateTime.UtcNow.Date,
                RentalEnd = DateTime.UtcNow.Date
            };

          
            decimal totalPrice = rentalCart.listRentalItems.Sum(item => item.car?.price ?? 0);
            ViewBag.TotalPrice = totalPrice;  

            return View(order); 
        }

        // POST: Order/Checkout
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
                rentalCart.ClearCart();        
                return RedirectToAction("Complete");  
            }

            
            var orderDetails = rentalCart.listRentalItems.Select(item => new OrderDetail
            {
                car = item.car,  
                price = item.car?.price ?? 0  
            }).ToList();
            order.orderDetails = orderDetails; 

            return View(order);  
        }

      
        public IActionResult Complete()
        {
            ViewBag.Message = "Оренда була успішно оброблена";
            return View();
        }
    }
}
