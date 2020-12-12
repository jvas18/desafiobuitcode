using System;
using System.Threading.Tasks;
using Desafio.Domain.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IDoctorService : IDisposable
    {
         Task Adicionar(Doctor doctor);
         Task Deletar(Guid id);
         Task Atualizar(Doctor doctor);
         
    }
}