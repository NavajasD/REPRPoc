using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REPRPoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Persistance.EntityConfiguration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Created)
                .IsRequired()
                .IsConcurrencyToken();

            builder.Property(c => c.LastModifiedBy)
                .IsRequired();

            builder.Property(c => c.Plate)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Maker)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Model)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
