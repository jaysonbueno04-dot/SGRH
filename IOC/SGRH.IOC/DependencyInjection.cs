using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGRH.Domain.Repository;
using SGRH.Persistence.Context;
using SGRH.Persistence.Repositories;

namespace SGRH.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSgrhServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HotelDbContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IPisoRepository, PisoRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IHuespedRepository, HuespedRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            return services;
        }
    }
}
