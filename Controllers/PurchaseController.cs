using MccordMission7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository { get; set; }
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart ca)
        {
            repository = temp;
            cart = ca;
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Carts.Count() == 0)
            {
                ModelState.AddModelError("", "You can't checkout until you've selected one book");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Carts.ToArray();
                repository.SavePurchase(purchase);
                cart.ClearCart();
                return RedirectToPage("/Complete");
            }
            else 
            {
                return View();
            }
        }
    }
}
