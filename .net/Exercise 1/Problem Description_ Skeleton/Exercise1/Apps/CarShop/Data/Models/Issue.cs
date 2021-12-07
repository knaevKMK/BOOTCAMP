

namespace CarShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Issue
    {
        [Key]
        public string Id { get; set; } =Guid.NewGuid().ToString();
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        [Required]
        public bool isFixed { get; set; }
        [Required]
        public string CarId { get; set; }
        public virtual Car Car { get; set; }

    }
}
