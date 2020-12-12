using System;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Desafio.Repository.Validation;

namespace Desafio.Repository.Services
{
    public class PatientService : BaseService, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository,
                                INotificador notificador) : base(notificador)
        {
            _patientRepository = patientRepository;
        }

        public async Task Adicionar(Patient patient)
        {
             if(!ExecutarValidacao(new PatientValidation(),patient)) return;

             if(await _patientRepository.CpfExists(patient.Cpf)){
                 Notificar("This document has been already regitered in our system!");
                return;
            }

            await _patientRepository.Add(patient);
        }

        public async Task Atualizar(Patient patient)
        {
             if(!ExecutarValidacao(new PatientValidation(),patient)) return;
             
           if(_patientRepository.Search(p => p.Cpf == patient.Cpf  && p.Id != patient.Id).Result.Any()){
                 Notificar("This document has been already registered in our system!");
                return;
            }
            await _patientRepository.Update(patient);
        }

        public async Task Deletar(Guid id)
        {
           var patient = await _patientRepository.GetPatient(id);
           await _patientRepository.Delete(patient);
        }

        public void Dispose()
        {
          _patientRepository?.Dispose();
        }
    }
}