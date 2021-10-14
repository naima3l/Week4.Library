using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Interfaces;
using Week4.Library.Core.Models;

namespace Week4.Library.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IBookRepository bookRepo;
        private readonly IPrestitoRepository prestitoRepo;

        public MainBusinessLayer(IBookRepository bookRepository, IPrestitoRepository prestitoRepository)
        {
            this.bookRepo = bookRepository;
            this.prestitoRepo = prestitoRepository;
        }

        public bool AddBook(Book newBook)
        {
            if (newBook == null)
                return false;

            //altrimenti
            return bookRepo.Add(newBook);
        }

        public bool DeleteBook(int idBook)
        {
            if (idBook <= 0)
                return false;

            Book bookToDelete = bookRepo.GetById(idBook);

            if (bookToDelete != null)
            {
                bool isDeleted = bookRepo.Delete(bookToDelete.Id);
                return isDeleted;
            }
            return false;

        }

        public Book GetById(int id)
        {
            if (id <= 0)
                return null;

            return bookRepo.GetById(id);
        }

        public bool EditBook(Book editedBook)
        {
            if (editedBook == null)
                return false;

            return bookRepo.Update(editedBook);
        }
        public List<Book> FetchBooks()
        {
            return bookRepo.Fetch();
        }

        public bool PrestitoLibro(Book book, string utente, DateTime date)
        {
            if (book == null || utente == null || date == null)
                return false;

            return prestitoRepo.Add(book,utente,date);
        }

        public bool ResoLibro(Book book, string utente, DateTime dataReso)
        {
            if (book == null)
                return false;

            return prestitoRepo.Update(book,utente, dataReso);
        }

        public bool AddPrestito(Prestito newPrestito)
        {
            if (newPrestito == null)
                return false;

            return prestitoRepo.Add(newPrestito);
        }

        public void EditPrestito(Prestito prestito)
        {
            if (prestito == null)
                return;

            prestitoRepo.Update(prestito);
        }
    }
}
