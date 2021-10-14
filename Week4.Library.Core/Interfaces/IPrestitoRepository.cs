using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Models;

namespace Week4.Library.Core.Interfaces
{
    public interface IPrestitoRepository : IRepository<Prestito>
    {
        bool Add(Book book, string utente, DateTime date);
        bool Update(Book book, string utente, DateTime dataReso);
    }
}
