using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Desafio.Domain.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> :IDisposable where TEntity : Entity
    {
        //GERAL
         Task Add (TEntity entity);
         Task Update (TEntity entity);
        Task Delete (TEntity entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
       
    }
}