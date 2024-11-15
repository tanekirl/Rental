﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Rental.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace Rental.Data
{
    public class DBObjects
    {

        public static async Task Initial(AppDBContent content, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            const string adminEmail = "admin@gmail.com";
            var user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                var defaultUser = new User() { Email = adminEmail, UserName = adminEmail };
                await userManager.CreateAsync(defaultUser, "password");
                user = defaultUser;
            }
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }

            if (content.Category.Any())
            {
                return;
            }

            Category classic = new() { categoryName = "Класика", desc = "Авто з двигунами внутрішнього згорання" };
            Category electro = new() { categoryName = "Електро", desc = "Сучасний вид траспорту" };
            content.Category.AddRange(classic, electro);

            if (!content.Car.Any())
            {
                content.AddRange(new List<Car>
                {
                    new Car
                    {
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
                            new CarImage { Url = "/img/BMW1.png" },
                            new CarImage { Url = "/img/BMW2.png" },
                            new CarImage { Url = "/img/BMW3.png" },
                            new CarImage { Url = "/img/BMW4.png" },
                            new CarImage { Url = "/img/BMW5.png" },
                            new CarImage { Url = "/img/BMW6.png" },
                            new CarImage { Url = "/img/BMW7.png" }
                        },
                        Category = classic
                    },
                    new Car
                    {

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
                            new CarImage { Url = "/img/TESLA1.png" },
                            new CarImage { Url = "/img/TESLA2.png" },
                            new CarImage { Url = "/img/TESLA3.png" },
                            new CarImage { Url = "/img/TESLA4.png" },
                            new CarImage { Url = "/img/TESLA5.png" },
                            new CarImage { Url = "/img/TESLA6.png" },
                            new CarImage { Url = "/img/TESLA7.png" }
                        },
                        Category = electro
                    },
                    new Car
                    {

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
                            new CarImage { Url = "/img/FORD1.png" },
                            new CarImage { Url = "/img/FORD2.png" },
                            new CarImage { Url = "/img/FORD3.png" },
                            new CarImage { Url = "/img/FORD4.png" },
                            new CarImage { Url = "/img/FORD5.png" },
                            new CarImage { Url = "/img/FORD6.png" },
                            new CarImage { Url = "/img/FORD7.png" }
                        },
                        Category = classic
                    },
                    new Car
                    {

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
                            new CarImage { Url = "/img/MERCEDES1.png" },
                            new CarImage { Url = "/img/MERCEDES2.png" },
                            new CarImage { Url = "/img/MERCEDES3.png" },
                            new CarImage { Url = "/img/MERCEDES4.png" },
                            new CarImage { Url = "/img/MERCEDES5.png" },
                            new CarImage { Url = "/img/MERCEDES6.png" },
                            new CarImage { Url = "/img/MERCEDES7.png" }
                        },
                        Category = classic
                    },
                    new Car
                    {

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
                            new CarImage { Url = "/img/PORSCHE1.png" },
                            new CarImage { Url = "/img/PORSCHE2.png" },
                            new CarImage { Url = "/img/PORSCHE3.png" },
                            new CarImage { Url = "/img/PORSCHE4.png" },
                            new CarImage { Url = "/img/PORSCHE5.png" },
                            new CarImage { Url = "/img/PORSCHE6.png" },
                            new CarImage { Url = "/img/PORSCHE7.png" }
                        },
                        Category = classic
                    }
                }
                );
            }

            content.SaveChanges();

        }
    }
}