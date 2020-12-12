using Desafio.Domain;
using Desafio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Repository.Mapping
{
    public class PatientsMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
          builder.HasKey(p=>p.Id);
          builder.Property(p=>p.Name)
          .IsRequired();
          builder.Property(p=>p.Cpf)
          .IsRequired();
          builder.Property(p=>p.BirthDate)
          .IsRequired();
        
            builder.HasOne(p=>p.Doctor)
           .WithMany(p=>p.Patients)
           .HasForeignKey(p=>p.DoctorId)
           .HasConstraintName("FK_Pacients_Doctor")
           .IsRequired();
           
         builder.ToTable("Patients");

        }
    }
}