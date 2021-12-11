
namespace Git.ViewModels.user
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

public    class LoginBindingModel
    {
        [Required]
        [StringLength(maximumLength:20,MinimumLength =5, ErrorMessage ="Username must be between 5 and 20 symbols")]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 symbols")]
        public string Password { get; set; }
    }
}