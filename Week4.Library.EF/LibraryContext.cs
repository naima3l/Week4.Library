using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core;
using Week4.Library.Core.Models;
using Week4.Library.EF.Configurations;

namespace Week4.Library.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Prestito> Prestiti { get; set; }

        public LibraryContext() : base()
        {

        }

        //Servirà dopo
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Server = (localdb)\mssqllocaldb;
                Database = LibraryDb; Trusted_Connection = True;";

                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Book>(new BookConfiguration());
        }
    }
}
