namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
public    class Car
    {
        [Key]
        public string Id { get; set; } =Guid.NewGuid().ToString();
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        [RegularExpression("[A-Z]{2}[1-9]{4}[A-Z]{2}")]
        public string PalteNumber { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
