using System;
using System.Collections.Generic;

namespace Desafio.Domain.Models
{
    public class Doctor : Entity
    {
        
        public string Name {get; set;}
        public string Crm{get;set;}
        public string CrmUf {get; set;}
        
        /*EF Relations*/
        public IEnumerable<Patient> Patients {get; set;}

        
    }
}