
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Desafio.API.DTOs;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController :  BaseController
    {
           private readonly IPatientRepository _patientRepository;
           private readonly IPatientService _patientService;
            private readonly IMapper _mapper;
            private readonly INotificador _notificador;

        public PatientController(IPatientRepository patientRepository,
                                IPatientService patientService,
                                INotificador notificador,
                                 IMapper mapper): base(notificador)
        {
            _mapper = mapper;
            _notificador = notificador;
            _patientService = patientService;
            _patientRepository = patientRepository;
        }

        [Route("patient-list")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try{
            var results =_mapper.Map<IEnumerable<PatientDTO>> (await _patientRepository.GetPatients());
            return Ok(results);
            }
            catch(Exception ex)
            {
                return Ok(ex);

            }
        }
        
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Create(PatientDTO patient)
        {
            try{
                
                     await _patientService.Adicionar(_mapper.Map<Patient>(patient));
                    if(await _patientRepository.SaveChangesAsync()){
                         return CreatedAtAction("List", patient);
                     }
                else
                {
                    return BadRequest(_notificador.ObterNotificacoes());
                }           
                    

                
     
              
            }
            catch(Exception ex)
            {
                 return this.StatusCode(500,"Banco de Dados Falhou");
            }



        }
        [Route("get-patient/{id}")]
        [HttpGet]
         public async Task<IActionResult> GetPatient(Guid id){
             try{
            var results =_mapper.Map<PatientDTO> (await _patientRepository.GetPatient(id));
            return Ok(results);
            }
            catch(Exception ex)
            {
                return Ok(ex);

            }

         }
         [HttpPost]
        [Route("edit-patient")]
        public async Task<IActionResult> Edit(PatientDTO patient)
        {
            try{
            var _patient =await  _patientRepository.GetPatient(patient.Id);

            if(_patient == null) return NotFound();

              
                 await _patientService.Atualizar(_mapper.Map<Patient>(patient));
                     if(await _patientRepository.SaveChangesAsync()){
                         return CreatedAtAction("Index", patient);
                     }
                    
                    else{
                        return BadRequest(_notificador);
                     }
                
                
       
          }
          catch(Exception ex)
            {
                 return this.StatusCode(500,"Banco de Dados Falhou");

            }
  
        } 
        [HttpGet]
        [Route("doctors-patients/{doctorId}")]
        public async Task<IActionResult> DoctorsReport(Guid doctorId)
        {
            try{
                var results =_mapper.Map<IEnumerable<PatientDTO>> (await _patientRepository.GetPatientsByDoctorId(doctorId));
                return Ok(results);
            }
            catch(Exception ex)
            {
                return Ok(ex);

            }

        }
        [HttpDelete]
        [Route("delete-patient/{patientId}")]
        public async Task<IActionResult> Delete(Guid patientId)
        {
             try{
                var _patient =await  _patientRepository.GetPatient(patientId);
                if(_patient == null) return NotFound();
                await _patientService.Deletar(patientId);
                 if(await _patientRepository.SaveChangesAsync()){
                         return CreatedAtAction("List", _patient);
             }
             else{
                 return BadRequest(_notificador.ObterNotificacoes());
             }
              


        }
        catch(Exception ex)
            {
                 return this.StatusCode(500,"Banco de Dados Falhou");

            }
    }

    }
    


}