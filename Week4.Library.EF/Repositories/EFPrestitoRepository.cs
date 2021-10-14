using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core;
using Week4.Library.Core.Interfaces;
using Week4.Library.Core.Models;

namespace Week4.Library.EF.Repositories
{
    public class EFPrestitoRepository : IPrestitoRepository
    {
        private readonly LibraryContext ctx;

        public EFPrestitoRepository()
        {
            ctx = new LibraryContext();
        }
        public bool Add(Prestito item)
        {
            try
            {
                ctx.Prestiti.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Add(Book book, string utente, DateTime date)
        {
            if (book == null || utente == null || date == null)
                return false;

            Prestito prestito = new Prestito();
            prestito.IdLibro = book.Id;
            prestito.Utente = utente;
            prestito.DataPrestito = date;

            try
            {
                ctx.Prestiti.Add(prestito);
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
            throw new NotImplementedException();
        }

        public List<Prestito> Fetch()
        {
            throw new NotImplementedException();
        }

        public Prestito GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Prestito item)
        {
            try
            {
                ctx.Prestiti.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Book book, string utente, DateTime dataReso)
        {
            if (book == null || utente == null)
                return false;
            int IdLibro = book.Id;
            Prestito prestito = ctx.Prestiti.Find(IdLibro,utente);
            prestito.DataReso = dataReso;

            try
            {
                ctx.Prestiti.Update(prestito);
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
