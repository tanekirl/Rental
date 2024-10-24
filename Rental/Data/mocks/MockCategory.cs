using Rental.Data.interfaces;
using Rental.Data.Models;

namespace Rental.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Електро", desc = "Сучасний вид траспорту" },
                    new Category { categoryName = "Класика", desc = "Авто з двигунами внутрішнього згорання" }
                };
            }
        }
    }
}