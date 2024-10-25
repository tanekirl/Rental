using Microsoft.EntityFrameworkCore;
using Rental.Data.interfaces;
using Rental.Data.Models;
using System.Collections.Generic; // Додайте цю директиву, якщо її ще немає

namespace Rental.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);

        public Car GetCar(int id)
        {
            // Використання Include з правильним простором імен
            return appDBContent.Car
                .Include(c => c.Category)
                .Include(c => c.Images)
                .FirstOrDefault(c => c.id == id);
        }
    }
}
