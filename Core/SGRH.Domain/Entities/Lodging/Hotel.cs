using SGRH.Domain.Base;

namespace SGRH.Domain.Entities.Lodging
{
    /// <summary>Schema [Lodging].[Hotel]</summary>
    public sealed class Hotel : AuditEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public ICollection<Piso> Pisos { get; set; } = new List<Piso>();
    }
}
