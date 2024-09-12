using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreWebApplication_DataAccess.Data;
using EFCoreWebApplication_Model.Models;
using EFCoreWebApplication_Model.ViewModels;

namespace EFCore_Web_Application.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //eager loading
            var books = _db.Books.Include(b => b.Category).Include(b => b.Publisher).Include(b => b.BookDetail).ToList();




            //for (int i = 0; i < books.Count; i++)
            //{
            //    books[i].Category = _db.Categories.Find(books[i].Category_Id);
            //   // books[i].Publisher = _db.Publishers.Find(books[i].Publisher_Id);

            //}

            //explicit loading

            //foreach (var book in books)
            //{
            //    _db.Entry(book).Reference(u=>u.Publisher).Load();
            //}
            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM book = new BookVM();
            book.PublisherList = _db.Publishers.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Publisher_Id.ToString()
            });
            book.CategorieList = _db.Categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            if (id == null)
            {
                book.Book = new Book();
                return View(book);
            }

            book.Book = _db.Books.Find(id);
            if (book.Book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Upsert(BookVM crbk)
        {
            if (ModelState.IsValid)
            {
                if (crbk.Book.Book_Id == 0)
                {
                    //CrBook.Book.BookDetail_Id = 1;
                    _db.Add(crbk.Book);
                }
                else
                {
                    _db.Update(crbk.Book);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crbk);
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void PlayGround()
        {
            #region Lazy Loading

            ////only when they are needed

            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //double totalPrice = 0;
            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}
            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();
            //var bookCount2 = _db.Books.Count();

            ////Until use ToList()

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            #endregion

            #region IEnumerable VS IQueryable
            // First, the complete data is loaded and then the filter is applied

            int a = 0;
            IEnumerable<Book> bookList = _db.Books;
            var filter = bookList.Where(b => b.Price > 500).ToList();

            //The filter happens in sql and then the data is loaded
            IQueryable<Book> bookListQ = _db.Books;
            var filterQ = bookListQ.Where(b => b.Price > 500).ToList();

            #endregion



        }
    }
}
