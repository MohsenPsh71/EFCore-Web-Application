using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCoreWebApplication_Model.Models;

namespace EFCoreWebApplication_Model.ViewModels
{
   public class BookAuthorVM
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
