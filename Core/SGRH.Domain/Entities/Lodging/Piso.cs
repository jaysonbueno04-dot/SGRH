using SGRH.Domain.Base;

namespace SGRH.Domain.Entities.Lodging
{
    /// <summary>Schema [Lodging].[Piso]</summary>
    public sealed class Piso : AuditEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Numero { get; set; }
        public string? Descripcion { get; set; }

        public Hotel? Hotel { get; set; }
        public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
    }
}
