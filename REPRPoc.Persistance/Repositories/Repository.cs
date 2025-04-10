using Microsoft.EntityFrameworkCore;
using REPRPoc.Contracts.Persistance;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Persistance.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext databaseContext;

        protected Repository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IUnitOfWork UnitOfWork => databaseContext;

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await databaseContext.AddAsync(entity, cancellationToken);
        }
        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var dbSet = databaseContext.Set<T>();

            if (predicate is null)
                return await dbSet.ToListAsync(cancellationToken);
            
            return await dbSet.Where(predicate).ToListAsync(cancellationToken);
        }
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await databaseContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }
        public void Remove(T entity)
        {
            databaseContext.Remove(entity);
        }
        public void Update(T entity)
        {
            databaseContext.Update(entity);
        }
    }
}
