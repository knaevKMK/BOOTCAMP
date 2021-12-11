
namespace Git.Data.Entities
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
public    class Repository
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
