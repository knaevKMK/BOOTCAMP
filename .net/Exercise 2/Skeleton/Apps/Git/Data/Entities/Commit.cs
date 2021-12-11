
namespace Git.Data.Entities
{
using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Commit
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        [Required]
        public string RepositoryId { get; set; }
        [ForeignKey("RepositoryId")]
        public Repository Repository { get; set; }
    }
}
