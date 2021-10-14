using System;
using System.Collections.Generic;
using System.Linq;
using Week4.Library.Core;
using Week4.Library.Core.Interfaces;

namespace Week4.Library.EF
{
    public class EFBookRepository : IBookRepository
    {
        private readonly LibraryContext ctx;

        public EFBookRepository()
        {
            ctx = new LibraryContext();
        }

        public bool Add(Book newBook)
        {
            if (newBook == null)
                return false;

            try
            {
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            try
            {
                var book = ctx.Books.Find(id);

                if (book != null)
                    ctx.Books.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Book> Fetch()
        {
            try
            {
                return ctx.Books.ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public Book GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Books.Find(id);
        }

        public Book GetByISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return null;

            try
            {
                var book = ctx.Books.Find(isbn);

                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Book updatedBook)
        {
            if (updatedBook == null)
                return false;

            try
            {
                ctx.Books.Update(updatedBook);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
