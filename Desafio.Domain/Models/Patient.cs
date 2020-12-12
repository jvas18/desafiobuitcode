

using System;

namespace Desafio.Domain.Models
{
    public class Patient : Entity
    {
        
        
        public string Name {get; set;}
        public DateTime  BirthDate {get;set;}
        public string Cpf {get; set;}
        public Guid DoctorId {get; set;}

        /*EF Relations*/

        public Doctor Doctor{get; set;}
    }
}