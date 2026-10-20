using SGRH.Domain.Base;
using SGRH.Domain.Entities.Guests;
using SGRH.Domain.Entities.Lodging;
using SGRH.Domain.Enums;

namespace SGRH.Domain.Entities.Bookings
{
    /// <summary>Schema [Bookings].[Reserva]</summary>
    public sealed class Reserva : AuditEntity
    {
        public int Id { get; set; }
        public int HuespedId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadHuespedes { get; set; }
        public decimal Total { get; set; }
        public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;

        public Huesped? Huesped { get; set; }
        public Habitacion? Habitacion { get; set; }
    }
}
