namespace Authentication.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Authentication.Infrastracture;
    using Microservice.Core;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        private readonly AuthContext authContext;

        public GenericRepository(AuthContext authContext)
        {
            this.authContext = authContext;
        }

        public async Task<Guid> Create(TEntity entity)
        {
            await authContext.Set<TEntity>().AddAsync(entity);
            await authContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            authContext.Set<TEntity>().Remove(entity);
            await authContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<TEntity> GetAll()
        {
            return authContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await authContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Guid id, TEntity entity)
        {
            authContext.Set<TEntity>().Update(entity);
            await authContext.SaveChangesAsync();
            return true;
        }
    }
}
