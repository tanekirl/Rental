using Rental.Data.Models;

namespace Rental.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getObjectCar(int carId);
        Car GetCar(int id);

    }
}