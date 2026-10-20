using SGRH.Domain.Entities.Guests;

namespace SGRH.Domain.Repository
{
    public interface IHuespedRepository : IBaseRepository<Huesped>
    {
        Task<Huesped?> GetByDocumentoAsync(string documento);
    }
}
