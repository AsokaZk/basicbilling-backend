using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        EntityEntry<TEntity> GetEntry(TEntity entity);

        Task<TEntity> Add(TEntity entity);

        Task<List<TEntity>> AddList(List<TEntity> entities);

        Task<TEntity> Update(TEntity entity);

        void Remove(TEntity entity);

    }
}