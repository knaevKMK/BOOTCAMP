using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.ViewModels.Users
{
    public class RegisterBindingModel
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 chars")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 chars")]
        public string Password { get; set; }
        [Required]
        //[Compare()]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 chars")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string   UserType { get; set; }
    }
}
