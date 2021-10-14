using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Library.Core.Interfaces
{
    public interface IBusinessLayer
    {
        bool AddBook(Book newBook);
        bool DeleteBook(int idBook);
        bool EditBook(Book editedBook);
        List<Book> FetchBooks();
        bool PrestitoLibro(Book book,string utente,DateTime date);
        bool ResoLibro(Book book, string utente, DateTime dataReso);
        Book GetById(int id);
    }
}
