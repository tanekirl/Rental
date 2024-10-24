using Rental.Data.Models;

namespace Rental.Data.interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}