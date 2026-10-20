using SGRH.Domain.Base;
using SGRH.Domain.Entities.Bookings;

namespace SGRH.Domain.Entities.Guests
{
    /// <summary>Schema [Guests].[Huesped]</summary>
    public sealed class Huesped : AuditEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
