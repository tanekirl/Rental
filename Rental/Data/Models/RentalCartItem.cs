namespace Rental.Data.Models
{
    public class RentalCartItem
    {
        public int id { get; set; }
        public int carid { get; set; }
        public Car car { get; set; }
        public decimal price { get; set; }
        public string RentalCartId { get; set; }
    }
}