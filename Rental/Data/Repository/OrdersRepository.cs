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

            var items = rentalCart.listRentalItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.id,
                    order = order,
                    price = el.car.price
                };
                order.orderDetails.Add(orderDetail);
            }
            order.OrderTime = DateTime.Now;

            appDBContent.Order.Add(order);



            appDBContent.SaveChanges();
        }
    }

}