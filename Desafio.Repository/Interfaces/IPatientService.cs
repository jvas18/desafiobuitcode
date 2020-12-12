using System;
using System.Threading.Tasks;
using Desafio.Domain.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IPatientService : IDisposable
    {
         Task Adicionar(Patient patient);
         Task Deletar(Guid id);
         Task Atualizar(Patient patient);

        
    }
}