namespace SGRH.Domain.Base
{
    /// <summary>Campos de auditoria comunes a todas las tablas (borrado logico incluido).</summary>
    public abstract class AuditEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
