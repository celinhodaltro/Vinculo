using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vinculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;.
using System.Threading.Tasks;

namespace Vinculo.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons"); 
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.OwnsOne(p => p.Cpf, cpf =>
            {
                cpf.Property(c => c.Value).HasColumnName("Cpf").IsRequired().HasMaxLength(11);
            });
        }
    }
}
