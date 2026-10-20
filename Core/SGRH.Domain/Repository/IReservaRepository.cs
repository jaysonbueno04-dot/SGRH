using SGRH.Domain.Entities.Bookings;

namespace SGRH.Domain.Repository
{
    public interface IReservaRepository : IBaseRepository<Reserva>
    {
        /// <summary>RN-006: true si la habitacion ya tiene una reserva activa que se solapa con el rango.</summary>
        Task<bool> ExisteSolapamientoAsync(int habitacionId, DateTime entrada, DateTime salida, int? excluirReservaId = null);
        Task<IEnumerable<Reserva>> GetByHuespedAsync(int huespedId);
    }
}
