using Book_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_library.Controllers
{
    public class BooksController : Controller
    {
        private readonly Book_libraryContext context;

        public BooksController(Book_libraryContext context)
        {
            this.context = context;
        }

        public enum HeaderElemnts
        {
            Title, Author, Genre, SharedWith, Pages
        }

        //// GET: Books by primary Title filter
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var books = from b in context.Book select b;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        books = books.Where(b =>b.Title.Contains(searchString));
        //    }

        //    return View(await books.ToListAsync());
        //}
        

        // GET: Books by Genre
        //public async Task<IActionResult> Index(string bookGenre, string searchString)
        //{
        //    IQueryable<string> genreQuery = from b in context.Book
        //                                    orderby b.Genre
        //                                    select b.Genre;

        //    var books = from b in context.Book select b;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        books = books.Where(b => b.Title.Contains(searchString));
        //    }

        //    if (!string.IsNullOrEmpty(bookGenre))
        //    {
        //        books = books.Where(b => b.Genre == bookGenre);
        //    }

        //    var bookGenreVM = new BookGenreViewModel
        //    {
        //        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //        Books = await books.ToListAsync()
        //    };

        //    return View(bookGenreVM);
        //}

        //Get Books by selected header type
        public async Task<IActionResult> Index(string headerType, string searchString)
        {
            var books = from b in context.Book select b;

            if (!string.IsNullOrEmpty(headerType))
            {

                switch (headerType)
                {
                    case "Title":
                        books = books.Where(b => b.Title.Contains(searchString));
                        break;
                    case "Author":
                        books = books.Where(b => b.Author.Contains(searchString));
                        break;
                    case "Genre":
                        books = books.Where(b => b.Genre.Contains(searchString));
                        break;
                    case "SharedWith":
                        books = books.Where(b => b.SharedWith.Contains(searchString));
                        break;
                    case "Pages":
                        books = books.Where(b => b.Pages == int.Parse(searchString));
                        break;
                    default:
                        break;
                }
            }

            var searchVM = new SearchViewModel
            {
                Books = await books.ToListAsync(),
                HeaderElements = new SelectList(Enum.GetValues(typeof(HeaderElemnts)).Cast<HeaderElemnts>())
            };

            return View(searchVM);
        }


        //begining of test code
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        //end of test code


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await context.Book
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Genre,SharedWith,Pages")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Genre,SharedWith,Pages")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(book);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await context.Book.FindAsync(id);
            context.Book.Remove(book);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return context.Book.Any(e => e.Id == id);
        }
    }
}
