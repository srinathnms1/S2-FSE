namespace Microservice.Core
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<Guid> Create(TEntity entity);
        Task<bool> Update(Guid id, TEntity entity);
        Task<bool> Delete(Guid id);
    }
}
