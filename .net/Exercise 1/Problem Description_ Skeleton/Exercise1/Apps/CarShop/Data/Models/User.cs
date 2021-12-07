
namespace CarShop.Data.Models
{
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  public  class User: IdentityUser<String>
    {
        //[Key]
        //public string Id { get; set; } = new Guid().ToString();
        //[Required]
        //[MinLength(4)]
        //[MaxLength(20)]
        //public string Username { get; set; }
        //[EmailAddress]
        //public string Email { get; set; }
        //[Required]
        //[MinLength(5)]
        //[MaxLength(20)]
        //public string Password { get; set; }

        public bool isMechanic { get; set; } = false;
        public virtual ICollection<Car> Cars { get; set; }
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
