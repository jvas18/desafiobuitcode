using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(DataContext db) : base(db)
        {
        }

        public async Task<bool> CpfExists(string cpf)
        {
            var patient = await Db.Patients.AsNoTracking()
            .FirstOrDefaultAsync(p=>p.Cpf == cpf);

            return patient != null;
        }

        public async Task<Patient> GetPatient(Guid id)
        {
              return await Db.Patients.AsNoTracking().FirstOrDefaultAsync(d=>d.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await Db.Patients.ToListAsync();
           
           
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctorId(Guid doctorId)
        {
            return await Db.Patients.Where(p=>p.DoctorId == doctorId).ToListAsync();
        }
    }
}