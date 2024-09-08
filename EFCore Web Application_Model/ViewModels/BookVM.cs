using EFCoreWebApplication_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCoreWebApplication_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem>? PublisherList { get; set; }
        public IEnumerable<SelectListItem>? CategorieList { get; set; }
    }
}
