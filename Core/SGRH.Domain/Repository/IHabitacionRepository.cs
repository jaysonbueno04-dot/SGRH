using SGRH.Domain.Entities.Lodging;

namespace SGRH.Domain.Repository
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        /// <summary>Habitaciones sin reservas activas que se crucen con el rango (RN-006) y con estado Disponible.</summary>
        Task<IEnumerable<Habitacion>> GetDisponiblesAsync(DateTime entrada, DateTime salida, int? capacidadMinima = null);
    }
}
