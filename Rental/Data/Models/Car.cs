﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.Data.Models
{
    public class Car
    {
        public Car()
        {
            Images = new List<CarImage>(); 
        }

        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; } 
        public decimal price { get; set; }
        public bool isFavourite { get; set; }
        public bool available { get; set; }
        public int seatingCapacity { get; set; }
        public string bodyType { get; set; }
        public int horsepower { get; set; }
        public decimal engineDisplacement { get; set; }
        public string fuelType { get; set; }
        public string color { get; set; }
        public string transmission { get; set; }
        public virtual ICollection<CarImage> Images { get; set; } 
        public int CategoryId { get; set; }
        [ValidateNever] public Category Category { get; set; }
        [NotMapped] public bool CarInCart { get; set; }
    }
}
