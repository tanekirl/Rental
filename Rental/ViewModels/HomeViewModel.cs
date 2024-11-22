using Rental.Data.Models;
using System.Collections.Generic;

namespace Rental.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
