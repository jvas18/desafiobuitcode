using AutoMapper;
using Desafio.API.DTOs;
using Desafio.Domain.Models;

namespace Desafio.API.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Doctor,DoctorDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}