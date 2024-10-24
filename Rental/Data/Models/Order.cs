using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Rental.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Ім'я")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина імені має бути не менше 2 символів")]
        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        public string name { get; set; }


        [Display(Name = "Прізвище")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина прізвища має бути не менше 2 символів")]
        [Required(ErrorMessage = "Прізвище є обов'язковим")]
        public string surname { get; set; }


        [Display(Name = "Адреса")]
        [Required(ErrorMessage = "Адреса є обов'язковою")]
        public string adress { get; set; }


        [Display(Name = "Телефон")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Невірний формат телефону. Введіть номер у форматі +380*********")]
        [StringLength(13, ErrorMessage = "Номер телефону має містити не більше 13 символів")]
        [Required(ErrorMessage = "Телефон є обов'язковим")]
        public string phone { get; set; }


        [Display(Name = "Електронна пошта")]
        [EmailAddress(ErrorMessage = "Невірний формат електронної пошти")]
        [Required(ErrorMessage = "Електронна пошта є обов'язковою")]
        public string email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }


        public List<OrderDetail> orderDetails { get; set; }


    }
}