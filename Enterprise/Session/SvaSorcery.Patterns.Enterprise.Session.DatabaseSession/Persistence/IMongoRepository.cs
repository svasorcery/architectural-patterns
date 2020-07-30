using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Persistence
{
    public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }

    public interface IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
