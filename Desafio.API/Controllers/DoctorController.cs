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
    public class DoctorController : BaseController
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;
        private INotificador _notificador;
      private readonly IMapper _mapper;
        public DoctorController(IMapper mapper,
                                INotificador notificador,
                                IDoctorService doctorService,
                                IDoctorRepository doctorRepository): base(notificador)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _notificador = notificador;
            _doctorService = doctorService;
        }

        [Route("doctors-list")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try{
            var results =_mapper.Map<IEnumerable<DoctorDTO>> (await _doctorRepository.GetDoctors());
            return Ok(results);
            }
            catch(Exception ex)
            {
                return Ok(ex);

            }
        }
        [Route("get-doctor/{id}")]
        [HttpGet]
         public async Task<IActionResult> GetDoctor(Guid id){
             try{
            var results =_mapper.Map<DoctorDTO> (await _doctorRepository.GetDoctor(id));
            return Ok(results);
            }
            catch(Exception ex)
            {
                return Ok(ex);

            }

         }


        [Route("add-doctor")]
        [HttpPost]
        public async Task<IActionResult> Create(DoctorDTO doctor)
        {
            try{
                
                     await _doctorService.Adicionar(_mapper.Map<Doctor>(doctor));
                    
                 if(await _doctorRepository.SaveChangesAsync()){
                         return CreatedAtAction("List", doctor);
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
        [HttpPost]
        [Route("edit-doctor")]
        public async Task<IActionResult> Edit(DoctorDTO doctor)
        {
            try{
            var _doctor =await  _doctorRepository.GetDoctor(doctor.Id);

            if(_doctor == null) return NotFound();
            await _doctorService.Atualizar(_mapper.Map<Doctor>(doctor));          
                  if(await _doctorRepository.SaveChangesAsync()){
                         return CreatedAtAction("List", doctor);
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

        
    
        [HttpDelete]
        [Route("delete-doctor/{doctorId}")]
        public async Task<IActionResult> Delete(Guid doctorId)
        {
             try{
                var _doctor =await  _doctorRepository.GetDoctor(doctorId);
                if(_doctor == null) return NotFound();
                await _doctorService.Deletar(doctorId);
                 if(await _doctorRepository.SaveChangesAsync()){
                         return CreatedAtAction("List", _doctor);
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