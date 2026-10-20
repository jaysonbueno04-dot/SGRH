using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Lodging;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class PisoRepository : BaseRepository<Piso>, IPisoRepository
    {
        public PisoRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<Piso>> GetByHotelAsync(int hotelId)
            => await Set.AsNoTracking().Where(p => p.HotelId == hotelId).OrderBy(p => p.Numero).ToListAsync();
    }
}
