using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Models.ViewModels
{
    public class BookViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageChanging PageChanging { get; set; }
    }
}
