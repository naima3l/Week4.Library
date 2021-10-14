using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Library.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByISBN(string isbn);
    }
}
