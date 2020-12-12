using System;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Desafio.Repository.Validation;

namespace Desafio.Repository.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        public DoctorService(IDoctorRepository doctorRepository,
                                IPatientRepository patientRepository,
                                INotificador notificador) : base(notificador)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public async Task Adicionar(Doctor doctor)
        {
            if(!ExecutarValidacao(new DoctorValidation(),doctor)) return;

            if(await _doctorRepository.CrmExists(doctor)){
                 Notificar("This document has been already registered in our system!");
                return;
            }

            await _doctorRepository.Add(doctor);         
        }

        public async Task Atualizar(Doctor doctor)
        {
            if(!ExecutarValidacao(new DoctorValidation(),doctor)) return;

            if(_doctorRepository.Search(d => d.Crm == doctor.Crm && d.CrmUf == doctor.CrmUf && d.Id != doctor.Id).Result.Any()){
                 Notificar("This document has been already registered in our system!");
                return;
            }
            await _doctorRepository.Update(doctor);
        }

        public async Task Deletar(Guid id)
        {
            if( _patientRepository.GetPatientsByDoctorId(id).Result.Any()){
                Notificar("The doctor has patients!");
                return;
            }
            var doctor = await _doctorRepository.GetDoctor(id);
            await _doctorRepository.Delete(doctor);
        }

        public void Dispose()
        {
           _doctorRepository?.Dispose();
           _patientRepository?.Dispose();
        }
    }
}