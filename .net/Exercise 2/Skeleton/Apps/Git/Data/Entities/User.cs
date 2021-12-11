
namespace Git.Data.Entities
{
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
public    class User :IdentityUser<String>
    {
        //[Key]
        //public String Id { get; set; } = Guid.NewGuid().ToString();
        //[Required]
        //[MaxLength(20)]
        //public string Username { get; set; }
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }
        //[Required]
        //[MaxLength(20)]
        //public string Password { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public virtual ICollection<Repository> Repositories { get; set; }= new HashSet<Repository>();
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();

    }
}
