using MccordMission7.Models;
using MccordMission7.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Controllers
{
    public class HomeController : Controller
    {
        private IBooksRepository repo;

        public HomeController(IBooksRepository newBook)
        {
            repo = newBook;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            int pageLength = 10;

            var hello = new BookViewModel
            {
                Books = repo.Books.OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageLength)
                .Take(pageLength),

                PageChanging = new PageChanging
                {
                    TotalBooks = repo.Books.Count(),
                    BooksPerPage = pageLength,
                    CurrentPage = pageNumber,
                }
            };
            return View(hello);
        }

    }
}
