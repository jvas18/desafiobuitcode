using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Domain;
using Desafio.Domain.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IPatientRepository: IBaseRepository<Patient>
    {
         Task<IEnumerable<Patient>> GetPatients();
         Task<Patient> GetPatient(Guid id);
         Task<IEnumerable<Patient>> GetPatientsByDoctorId(Guid doctorId);
        Task<bool> CpfExists(string cpf);
    }
}
