using Rental.Data.interfaces;
using Rental.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rental.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars;

        public MockCars()
        {
            _categoryCars = new MockCategory();
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        id = 1,
                        name = "BMW M4",
                        shortDesc = "Зухвалість",
                        longDesc = "Автомобіль для тих, хто хоче відчути себе королем дороги",
                        img = "/img/BMW.png",
                        price = 3500,
                        isFavourite = true,
                        available = true,
                        seatingCapacity = 4,
                        bodyType = "Купе",
                        horsepower = 503,
                        engineDisplacement = 3.0m,
                        fuelType = "Бензин",
                        color = "Синій",
                        transmission = "Автомат",
                        Images = new List<CarImage>
                        {
                            new CarImage { Id = 1, Url = "/img/BMW1.png" },
                            new CarImage { Id = 2, Url = "/img/BMW2.png" },
                            new CarImage { Id = 3, Url = "/img/BMW3.png" },
                            new CarImage { Id = 4, Url = "/img/BMW4.png" },
                            new CarImage { Id = 5, Url = "/img/BMW5.png" },
                            new CarImage { Id = 6, Url = "/img/BMW6.png" },
                            new CarImage { Id = 7, Url = "/img/BMW7.png" }
                        },
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        id = 2,
                        name = "Tesla Model S",
                        shortDesc = "Надійність",
                        longDesc = "Лаконічність, екологічність та тиша - це про Tesla",
                        img = "/img/Tesla.png",
                        price = 3400,
                        isFavourite = false,
                        available = true,
                        seatingCapacity = 5,
                        bodyType = "Седан",
                        horsepower = 1020,
                        engineDisplacement = 0.0m, // електричний
                        fuelType = "Електричний",
                        color = "Червоний",
                        transmission = "Автомат",
                        Images = new List<CarImage>
                        {
                            new CarImage { Id = 1, Url = "/img/TESLA1.png" },
                            new CarImage { Id = 2, Url = "/img/TESLA2.png" },
                            new CarImage { Id = 3, Url = "/img/TESLA3.png" },
                            new CarImage { Id = 4, Url = "/img/TESLA4.png" },
                            new CarImage { Id = 5, Url = "/img/TESLA5.png" },
                            new CarImage { Id = 6, Url = "/img/TESLA6.png" },
                            new CarImage { Id = 7, Url = "/img/TESLA7.png" }
                        },
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        id = 3,
                        name = "Ford Fiesta",
                        shortDesc = "Спокій",
                        longDesc = "Зручний автомобіль для міського життя",
                        img = "/img/Ford.png",
                        price = 2700,
                        isFavourite = false,
                        available = true,
                        seatingCapacity = 5,
                        bodyType = "Хетчбек",
                        horsepower = 120,
                        engineDisplacement = 1.0m,
                        fuelType = "Бензин",
                        color = "Чорний",
                        transmission = "Автомат",
                        Images = new List<CarImage>
                        {
                            new CarImage { Id = 1, Url = "/img/FORD1.png" },
                            new CarImage { Id = 2, Url = "/img/FORD2.png" },
                            new CarImage { Id = 3, Url = "/img/FORD3.png" },
                            new CarImage { Id = 4, Url = "/img/FORD4.png" },
                            new CarImage { Id = 5, Url = "/img/FORD5.png" },
                            new CarImage { Id = 6, Url = "/img/FORD6.png" },
                            new CarImage { Id = 7, Url = "/img/FORD7.png" }
                        },
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        id = 4,
                        name = "Mercedes-Benz GLE-Class",
                        shortDesc = "Престиж",
                        longDesc = "Якщо знаєш собі ціну - цей автомобіль для тебе",
                        img = "/img/Mercedes.png",
                        price = 3150,
                        isFavourite = true,
                        available = true,
                        seatingCapacity = 5,
                        bodyType = "Кросовер",
                        horsepower = 362,
                        engineDisplacement = 3.0m,
                        fuelType = "Бензин",
                        color = "Сірий",
                        transmission = "Автомат",
                        Images = new List<CarImage>
                        {
                            new CarImage { Id = 1, Url = "/img/MERCEDES1.png" },
                            new CarImage { Id = 2, Url = "/img/MERCEDES2.png" },
                            new CarImage { Id = 3, Url = "/img/MERCEDES3.png" },
                            new CarImage { Id = 4, Url = "/img/MERCEDES4.png" },
                            new CarImage { Id = 5, Url = "/img/MERCEDES5.png" },
                            new CarImage { Id = 6, Url = "/img/MERCEDES6.png" },
                            new CarImage { Id = 7, Url = "/img/MERCEDES7.png" }
                        },
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        id = 5,
                        name = "Porsche 911",
                        shortDesc = "Швидкість",
                        longDesc = "Монстр, що підкориться тільки справжнім поціновувачам швидкості",
                        img = "/img/Porsche.png",
                        price = 4000,
                        isFavourite = true,
                        available = true,
                        seatingCapacity = 2,
                        bodyType = "Купе",
                        horsepower = 443,
                        engineDisplacement = 3.0m,
                        fuelType = "Бензин",
                        color = "Червоний",
                        transmission = "Автомат",
                        Images = new List<CarImage>
                        {
                            new CarImage { Id = 1, Url = "/img/PORSCHE1.png" },
                            new CarImage { Id = 2, Url = "/img/PORSCHE2.png" },
                            new CarImage { Id = 3, Url = "/img/PORSCHE3.png" },
                            new CarImage { Id = 4, Url = "/img/PORSCHE4.png" },
                            new CarImage { Id = 5, Url = "/img/PORSCHE5.png" },
                            new CarImage { Id = 6, Url = "/img/PORSCHE6.png" },
                            new CarImage { Id = 7, Url = "/img/PORSCHE7.png" }
                        },
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }

        public IEnumerable<Car> getFavCars => Cars.Where(c => c.isFavourite);

        public Car getObjectCar(int carId)
        {
            return Cars.FirstOrDefault(c => c.id == carId);
        }

        public Car GetCar(int id)
        {
            return Cars.FirstOrDefault(c => c.id == id);
        }
    }
}
