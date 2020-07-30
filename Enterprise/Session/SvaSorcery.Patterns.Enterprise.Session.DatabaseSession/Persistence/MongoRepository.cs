using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Persistence
{
	public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : IIdentifiable
	{
		protected IMongoCollection<TEntity> Collection { get; }

		public MongoRepository(IMongoDatabase database, string collectionName)
		{
			Collection = database.GetCollection<TEntity>(collectionName);
		}

		public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
			=> Collection.Find(predicate).AnyAsync();

		public Task<TEntity> GetAsync(Guid id)
			=> GetAsync(e => e.Id == id);

		public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
			=> Collection.Find(predicate).SingleOrDefaultAsync();

		public Task CreateAsync(TEntity entity)
			=> Collection.InsertOneAsync(entity);

		public Task UpdateAsync(TEntity entity)
			=> Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);

		public Task DeleteAsync(Guid id)
			=> Collection.DeleteOneAsync(e => e.Id == id);
	}
}
