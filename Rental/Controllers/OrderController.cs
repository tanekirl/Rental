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
            // Отримуємо всі елементи кошика
            rentalCart.listRentalItems = rentalCart.getRentalItems();

            // Перевіряємо, чи кошик порожній
            if (rentalCart.listRentalItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваш кошик пустий");
            }

            // Створюємо деталі замовлення на основі елементів кошика
            var orderDetails = rentalCart.listRentalItems.Select(item => new OrderDetail
            {
                car = item.car,  // Переконайтеся, що item.Car != null
                price = item.car?.price ?? 0  // Якщо ціна машини null, заміняємо на 0
            }).ToList();

            // Створюємо об'єкт замовлення з деталями
            var order = new Order
            {
                orderDetails = orderDetails
            };

            // Обчислюємо загальну суму замовлення
            decimal totalPrice = rentalCart.listRentalItems.Sum(item => item.car?.price ?? 0);
            ViewBag.TotalPrice = totalPrice;  // Передаємо через ViewBag для відображення в представленні

            return View(order);  // Передаємо модель в представлення
        }

        // POST: Order/Checkout
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            // Отримуємо елементи кошика
            rentalCart.listRentalItems = rentalCart.getRentalItems();

            // Перевіряємо, чи кошик порожній
            if (rentalCart.listRentalItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваш кошик пустий");
            }

            // Якщо модель коректна, зберігаємо замовлення і очищаємо кошик
            if (ModelState.IsValid)
            {
                allorders.createOrder(order);  // Створення замовлення
                rentalCart.ClearCart();         // Очищення кошика після оформлення замовлення
                return RedirectToAction("Complete");  // Перехід до сторінки підтвердження
            }

            return View(order);  // Повертаємо на сторінку оформлення, якщо є помилки
        }

        // Сторінка підтвердження замовлення
        public IActionResult Complete()
        {
            ViewBag.Message = "Оренда була успішно оброблена";
            return View();
        }
    }
}
