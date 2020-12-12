using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>  where TEntity : Entity, new()
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public BaseRepository(DataContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<bool> SaveChangesAsync()
        {
          return (await Db.SaveChangesAsync())>0;

        }
        public async Task Delete(TEntity entity)
        {
            Db.Remove(entity);
        }

       

        public async Task Add(TEntity entity)
        {
             await Db.AddAsync(entity);
        }

        public  async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
           
        }
          public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
           Db?.Dispose();
        }
    }
}