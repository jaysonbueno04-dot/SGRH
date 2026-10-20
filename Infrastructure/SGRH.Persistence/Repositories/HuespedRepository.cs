using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Guests;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class HuespedRepository : BaseRepository<Huesped>, IHuespedRepository
    {
        public HuespedRepository(HotelDbContext context) : base(context) { }

        public async Task<Huesped?> GetByDocumentoAsync(string documento)
            => await Set.AsNoTracking().FirstOrDefaultAsync(h => h.Documento == documento);
    }
}
