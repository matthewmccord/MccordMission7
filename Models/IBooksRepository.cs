using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; }
    }
}
