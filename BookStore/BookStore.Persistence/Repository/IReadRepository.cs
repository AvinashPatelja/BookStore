using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookStore.Persistence.Repository
{
    public interface IReadRepository<TEntity>
    {
        IQueryable<TEntity> All();
        TEntity FindByKey(Guid id);
    }
}
