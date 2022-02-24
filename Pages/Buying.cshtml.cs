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

        public BuyingModel (IBooksRepository temporary)
        {
            repo = temporary;
        }

        public Cart cart { get; set; }
        
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
