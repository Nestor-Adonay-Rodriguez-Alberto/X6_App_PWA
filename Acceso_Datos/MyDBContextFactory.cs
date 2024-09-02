using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Acceso_Datos
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBcontext>
    {
        public MyDBcontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBcontext>();
            const string Cadena_Conexion = "Data Source=.;Initial Catalog=X6_App_PWA;Integrated Security=True;Trust Server Certificate=True";
            const string Cadena_Conexion_2 = "workstation id=X6_App_PWA.mssql.somee.com;packet size=4096;user id=Test_Proyect_SQLLogin_6;pwd=9256kr1pvh;data source=X6_App_PWA.mssql.somee.com;persist security info=False;initial catalog=X6_App_PWA;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(Cadena_Conexion_2);

            return new MyDBcontext(optionsBuilder.Options);
        }
    }
}
