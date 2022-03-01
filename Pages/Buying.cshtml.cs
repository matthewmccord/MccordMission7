using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MccordMission7.Infrastructure;
using MccordMission7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MccordMission7.Pages
{
    public class BuyingModel : PageModel
    {
        private IBooksRepository repo { get; set; }

        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }

        public BuyingModel (IBooksRepository temporary, Cart ca)
        {
            repo = temporary;
            cart = ca;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            cart.RemoveItem(cart.Carts.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl });
        }
    }
}
