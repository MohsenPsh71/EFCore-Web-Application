using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApplication_Model.Models
{
   public class Author
    {
        [Key]
      //  [DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.Identity)]
        public int Author_Id { get; set; }
        [Required]
        [MaxLength(400)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(400)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }


        [NotMapped]
        public string FullName {
            get { return $"{FirstName} {LastName}"; } }

    }
}
