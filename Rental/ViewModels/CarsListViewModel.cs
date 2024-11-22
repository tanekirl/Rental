using Rental.Data.Models;

namespace Rental.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string currCategory { get; set; }
        public Car Car { get; set; }
    }
}