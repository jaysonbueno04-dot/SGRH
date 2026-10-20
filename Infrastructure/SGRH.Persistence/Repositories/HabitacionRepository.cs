using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Lodging;
using SGRH.Domain.Enums;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        public HabitacionRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<Habitacion>> GetDisponiblesAsync(DateTime entrada, DateTime salida, int? capacidadMinima = null)
        {
            var query = Set.AsNoTracking()
                .Where(h => h.Estado == EstadoHabitacion.Disponible)
                .Where(h => !h.Reservas.Any(r =>
                    !r.Deleted
                    && r.Estado != EstadoReserva.Cancelada
                    && r.Estado != EstadoReserva.NoPresentado
                    && r.FechaEntrada < salida
                    && r.FechaSalida > entrada));

            if (capacidadMinima.HasValue)
                query = query.Where(h => h.Capacidad >= capacidadMinima.Value);

            return await query.ToListAsync();
        }
    }
}
