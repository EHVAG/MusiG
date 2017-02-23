using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHVAG.MusiGModel
{
    public class Channel
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}