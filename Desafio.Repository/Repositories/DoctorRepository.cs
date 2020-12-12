using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Domain;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {

        public DoctorRepository(DataContext db) : base(db)
        {
            
        }

        public async Task<bool> CrmExists(Doctor entity)
        {
            var doctor = await Db.Doctors.AsNoTracking()
           .FirstOrDefaultAsync(p=>(p.Crm + p.CrmUf) == (entity.Crm+entity.CrmUf));

           return doctor != null;
        }

        public async Task<Doctor> GetDoctor(Guid id)
        {
            return await Db.Doctors.AsNoTracking().FirstOrDefaultAsync(d=>d.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await Db.Doctors.AsNoTracking()
            .ToListAsync();
        }
    }
}