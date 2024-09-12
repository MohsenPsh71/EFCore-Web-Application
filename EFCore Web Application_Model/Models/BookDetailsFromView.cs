using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApplication_Model.Models
{
   public class BookDetailsFromView
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
