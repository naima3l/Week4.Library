using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Models;

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
        bool AddPrestito(Prestito newPrestito);
        void EditPrestito(Prestito prestito);
        List<Prestito> FetchPrestiti();
    }
}
