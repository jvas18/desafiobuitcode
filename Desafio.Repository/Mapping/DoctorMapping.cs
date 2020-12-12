using Desafio.Domain;
using Desafio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Repository.Mapping
{
    public class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
           builder.HasKey(p=>p.Id);
       

           builder.Property(p=>p.Name)
           .IsRequired();

           builder.Property(p=>p.Crm)
           .IsRequired();

           builder.Property(p=>p.CrmUf)
           .IsRequired();

           builder.ToTable("Doctors");

        }
    }
}