using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Rental.Data.Models
{
    public class CarImage
    {
        public int Id { get; set; } // первинний ключ
        public string Url { get; set; } // URL зображення
        public int CarId { get; set; } // зовнішній ключ для Car
        [ValidateNever] public Car Car { get; set; } // навігаційна властивість
    }
}
