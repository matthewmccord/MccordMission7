using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Models
{
    public class Cart
    {

        public List<CartItem> Carts { get; set; } = new List<CartItem>();
        
        public void AddItem(Book bo, int qty)
        {
            CartItem line = Carts
                .Where(p => p.Book.BookId == bo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Carts.Add(new CartItem
                {
                    Book = bo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateSub()
        {
            double total = Carts.Sum(x => x.Quantity * x.Book.Price);
            return total;
        }
        
    }

    public class CartItem
    {
        public int ItemID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
