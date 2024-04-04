using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.context;

namespace Persistence.Repositories
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        private readonly BasicBillingContext basicBillingContext;

        public Repository(BasicBillingContext basicBillingContext)
        {
            this.basicBillingContext = basicBillingContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return this.basicBillingContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public EntityEntry<TEntity> GetEntry(TEntity entity)
        {
            try
            {
                return this.basicBillingContext.Entry(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                this.basicBillingContext.Add(entity);
                await this.basicBillingContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
        public async Task<List<TEntity>> AddList(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                this.basicBillingContext.AddRange(entities);
                await this.basicBillingContext.SaveChangesAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved: {ex.Message}");
            }
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                this.basicBillingContext.Update(entity);
                await this.basicBillingContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public void Remove(TEntity entity)
        {
            try
            {
                this.basicBillingContext.Remove(entity);
                this.basicBillingContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
    }
}