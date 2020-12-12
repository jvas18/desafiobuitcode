using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.API.DTOs
{
    public class PatientDTO
    {
         [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string BirthDate { get; set; }
        public string DoctorId { get; set; }
    }
}