using SGRH.Domain.Base;
using SGRH.Domain.Entities.Bookings;
using SGRH.Domain.Enums;

namespace SGRH.Domain.Entities.Lodging
{
    /// <summary>Schema [Lodging].[Habitacion]</summary>
    public sealed class Habitacion : AuditEntity
    {
        public int Id { get; set; }
        public int PisoId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public TipoHabitacion Tipo { get; set; }
        public int Capacidad { get; set; }
        public decimal PrecioNoche { get; set; }
        public EstadoHabitacion Estado { get; set; } = EstadoHabitacion.Disponible;

        public Piso? Piso { get; set; }
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
