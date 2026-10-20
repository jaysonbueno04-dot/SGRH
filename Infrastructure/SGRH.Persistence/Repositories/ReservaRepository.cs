using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Bookings;
using SGRH.Domain.Enums;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(HotelDbContext context) : base(context) { }

        public async Task<bool> ExisteSolapamientoAsync(int habitacionId, DateTime entrada, DateTime salida, int? excluirReservaId = null)
            => await Set.AnyAsync(r =>
                r.HabitacionId == habitacionId
                && (excluirReservaId == null || r.Id != excluirReservaId)
                && r.Estado != EstadoReserva.Cancelada
                && r.Estado != EstadoReserva.NoPresentado
                && r.FechaEntrada < salida
                && r.FechaSalida > entrada);

        public async Task<IEnumerable<Reserva>> GetByHuespedAsync(int huespedId)
            => await Set.AsNoTracking().Where(r => r.HuespedId == huespedId).OrderByDescending(r => r.FechaEntrada).ToListAsync();
    }
}
