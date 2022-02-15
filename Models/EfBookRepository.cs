using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Models
{
    public class EfBookRepository : IBooksRepository
    {
        private BookstoreContext context { get; set; }
        public EfBookRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
