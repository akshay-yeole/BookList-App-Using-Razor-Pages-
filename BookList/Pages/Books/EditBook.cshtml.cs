using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.Books
{
    public class EditBookModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        
        [BindProperty]
        public Book Book { get; set; }
        
        public EditBookModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Book bookfromdb = await _db.Book.FindAsync(Book.Id);
                bookfromdb.Name = Book.Name;
                bookfromdb.Author = Book.Author;
                bookfromdb.Quantity = Book.Quantity;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
