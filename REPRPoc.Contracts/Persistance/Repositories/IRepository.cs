using REPRPoc.Entities;
using System.Linq.Expressions;

namespace REPRPoc.Contracts.Persistance.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task AddAsync(T entity, Guid createdBy, CancellationToken cancellationToken = default);
        public void Remove(T entity);
        public void Update(T entity, Guid modifiedBy);
        public void SoftDelete(T entity, Guid modifiedBy);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        public Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
        public Task <bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
