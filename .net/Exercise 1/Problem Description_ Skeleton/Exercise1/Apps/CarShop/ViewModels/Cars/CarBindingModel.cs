namespace CarShop.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
 public class CarBindingModel
    {
        [Required]
        [StringLength(maximumLength:20,MinimumLength =5,ErrorMessage ="Model must be between 5 and 20 chars")]
        public string Model { get; set; }
        [Required]
        
        public int Year { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [RegularExpression("[A-Z]{2}[1-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }
    }
}
