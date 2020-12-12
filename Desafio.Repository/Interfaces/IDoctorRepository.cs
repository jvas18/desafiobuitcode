using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Domain;
using Desafio.Domain.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
         Task<IEnumerable<Doctor>> GetDoctors();
         Task<Doctor> GetDoctor(Guid id);
         Task<bool> CrmExists(Doctor entity);
    }
}