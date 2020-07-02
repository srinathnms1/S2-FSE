namespace Booking.Infrastructure
{
    using Microservice.Core;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        private readonly BookingContext bookingContext;

        public GenericRepository(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<Guid> Create(TEntity entity)
        {
            try
            {
                bookingContext.Set<TEntity>().Add(entity);
                bookingContext.SaveChanges();
                return await Task.Run(() => entity.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            bookingContext.Set<TEntity>().Remove(entity);
            await bookingContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<TEntity> GetAll()
        {
            return bookingContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await bookingContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Guid id, TEntity entity)
        {
            bookingContext.Set<TEntity>().Update(entity);
            await bookingContext.SaveChangesAsync();
            return true;
        }
    }
}
