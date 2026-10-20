using SGRH.Domain.Entities.Lodging;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelDbContext context) : base(context) { }
    }
}
