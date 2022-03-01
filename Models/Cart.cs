using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Models
{
    public class Cart
    {

        public List<CartItem> Carts { get; set; } = new List<CartItem>();
        
        public virtual void AddItem(Book bo, int qty)
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

        public virtual void RemoveItem(Book bo)
        {
            Carts.RemoveAll(x => x.Book.BookId == bo.BookId);
        }

        public virtual void ClearCart()
        {
            Carts.Clear();
        }
        public double CalculateSub()
        {
            double total = Carts.Sum(x => x.Quantity * x.Book.Price);
            return total;
        }
        
    }

    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
