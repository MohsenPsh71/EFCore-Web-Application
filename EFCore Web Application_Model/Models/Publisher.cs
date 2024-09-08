using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApplication_Model.Models
{
   public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required]
        [MaxLength(400)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
