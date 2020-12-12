using System;

namespace Desafio.Domain.Models
{
     public abstract class Entity
    {
        public Guid Id { get; set; }
        protected Entity()
        {
            Id = new Guid();
        }

    }
}