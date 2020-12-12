using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.API.DTOs
{
    public class DoctorDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Crm { get; set; }
        public string CrmUf { get; set; }
    }
}