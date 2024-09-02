using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acceso_Datos
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyeccion
            services.AddDbContext<MyDBcontext>(options => options.UseSqlServer(configuration.GetConnectionString("Cadena_Conexion_2")));

            // Accesos A Las Tablas
            services.AddScoped<RolDAL>();
            services.AddScoped<EmpleadoDAL>();
            services.AddScoped<FacturaDAL>();
            services.AddScoped<ReportesDAL>();

            return services;
        }
    }
}
