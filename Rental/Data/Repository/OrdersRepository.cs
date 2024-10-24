using Rental.Data.interfaces;
using Rental.Data.Models;

namespace Rental.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly RentalCart rentalCart;

        public OrdersRepository(AppDBContent appDBContent, RentalCart rentalCart)
        {
            this.appDBContent = appDBContent;
            this.rentalCart = rentalCart;
        }



        public void createOrder(Order order)
        {

            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = rentalCart.listRentalItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }

}