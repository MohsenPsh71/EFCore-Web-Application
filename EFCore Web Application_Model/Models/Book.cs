using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApplication_Model.Models
{
   public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }

        [NotMapped]
        public string PriceRange { get; set; }
    }
}
