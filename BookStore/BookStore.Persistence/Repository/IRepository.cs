using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Persistence.Repository
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>
    {
        void Insert(TEntity entity);
        void SaveChanges();
    }
}
