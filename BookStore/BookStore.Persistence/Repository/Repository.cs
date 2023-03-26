using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Persistence.Repository
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;
        

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity FindByKey(Guid id)
        {
            Expression<Func<TEntity, bool>> lambda = ExpressionUtility.BuildLambdaForFindByKey<TEntity>(id);
            return _dbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
    public static class ExpressionUtility
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(Guid id)
        {
            var item = Expression.Parameter(typeof(TEntity));
            var prop = Expression.Property(item, "id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}
