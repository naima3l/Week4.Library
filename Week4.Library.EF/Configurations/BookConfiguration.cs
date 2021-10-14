using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core;

namespace Week4.Library.EF.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Isbn)
                .IsRequired();

            builder
                .Property(b => b.Title)
                .IsRequired();

            builder
                .Property(b => b.Author);
        }
    }
}
