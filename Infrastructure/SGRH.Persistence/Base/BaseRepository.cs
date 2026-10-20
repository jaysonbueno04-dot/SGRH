using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Base;
using SGRH.Domain.Repository;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : AuditEntity
    {
        protected readonly HotelDbContext Context;
        protected readonly DbSet<TEntity> Set;

        protected BaseRepository(HotelDbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id) => await Set.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await Set.AsNoTracking().ToListAsync();

        public virtual async Task AddAsync(TEntity entity)
        {
            await Set.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            entity.ModifyDate = DateTime.Now;
            Set.Update(entity);
            await Context.SaveChangesAsync();
        }

        /// <summary>Borrado logico: marca Deleted = true.</summary>
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Set.FindAsync(id);
            if (entity is null) return;
            entity.Deleted = true;
            entity.DeletedDate = DateTime.Now;
            await Context.SaveChangesAsync();
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter) => await Set.AnyAsync(filter);
    }
}
