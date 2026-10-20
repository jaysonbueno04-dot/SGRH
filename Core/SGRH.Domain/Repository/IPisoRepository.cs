using SGRH.Domain.Entities.Lodging;

namespace SGRH.Domain.Repository
{
    public interface IPisoRepository : IBaseRepository<Piso>
    {
        Task<IEnumerable<Piso>> GetByHotelAsync(int hotelId);
    }
}
