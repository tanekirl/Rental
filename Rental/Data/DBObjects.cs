using Microsoft.AspNetCore.Builder;
using Rental.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace Rental.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {



            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla Model S ",
                        shortDesc = "Надійність",
                        longDesc = "Лаконічність екологісність та тиша - це про Tesla",
                        img = "/img/Tesla.png",
                        price = 3400,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Електро"]
                    },

                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Спокій",
                        longDesc = "Зручний автомобіль для міського життя",
                        img = "/img/Ford.png",
                        price = 2700,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Класика"]
                    },

                    new Car
                    {
                        name = "BMW M4",
                        shortDesc = "Зухвалість",
                        longDesc = "Автомобіль для тих, хто хоче відчути себе королем дороги",
                        img = "/img/BMW.png",
                        price = 3500,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класика"]
                    },

                    new Car
                    {
                        name = "Mercedes-Benz GLE-Class",
                        shortDesc = "Престиж",
                        longDesc = "Якщо знаєш собі ціну - цей автмобіль для тебе",
                        img = "/img/Mercedes.png",
                        price = 3150,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класика"]
                    },

                    new Car
                    {
                        name = "Porsche 911",
                        shortDesc = "Швидкість",
                        longDesc = "Монстр, що підкориться тільки справжнім поціновувачам швидкості",
                        img = "/img/Porsche.png",
                        price = 4000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класика"]
                    }


                    );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category { categoryName = "Електро", desc = "Сучасний вид траспорту" },
                         new Category { categoryName = "Класика", desc = "Авто з двигунами внутрішнього згорання" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);

                }
                return category;
            }
        }
    }
}