using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Bookings;
using SGRH.Domain.Entities.Guests;
using SGRH.Domain.Entities.Lodging;

namespace SGRH.Persistence.Context
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hoteles => Set<Hotel>();
        public DbSet<Piso> Pisos => Set<Piso>();
        public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
        public DbSet<Huesped> Huespedes => Set<Huesped>();
        public DbSet<Reserva> Reservas => Set<Reserva>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Hotel>().ToTable("Hotel", "Lodging").HasQueryFilter(e => !e.Deleted);
            b.Entity<Piso>().ToTable("Piso", "Lodging").HasQueryFilter(e => !e.Deleted);
            b.Entity<Habitacion>(e =>
            {
                e.ToTable("Habitacion", "Lodging").HasQueryFilter(x => !x.Deleted);
                e.Property(x => x.PrecioNoche).HasPrecision(10, 2);
            });
            b.Entity<Huesped>().ToTable("Huesped", "Guests").HasQueryFilter(e => !e.Deleted);
            b.Entity<Reserva>(e =>
            {
                e.ToTable("Reserva", "Bookings").HasQueryFilter(x => !x.Deleted);
                e.Property(x => x.Total).HasPrecision(12, 2);
            });

            // Evita borrado en cascada: se usa borrado logico
            foreach (var fk in b.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
