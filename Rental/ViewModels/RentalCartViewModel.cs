using Rental.Data.Models;

namespace Rental.ViewModels
{
    public class RentalCartViewModel
    {
        public RentalCart rentalCart { get; set; }
        public decimal TotalPrice { get; set; } // Додано поле для загальної ціни
    }
}
