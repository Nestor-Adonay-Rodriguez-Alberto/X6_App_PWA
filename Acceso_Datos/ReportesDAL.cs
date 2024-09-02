using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Acceso_Datos
{
    public class ReportesDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public ReportesDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Lista De La Tabla Empleados Para ViewData:
        public async Task<List<Empleado>> Lista_Empleados()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Empleados.ToListAsync();

            return Objetos_Obtenidos;
        }

        // Encuentra y Manda Los Objetos Con Ese Id:
        public async Task<List<Factura>> Facturas_Realizadas(int ID)
        {
            var Objetos_Obtenido = await _MyDBcontext.Facturas
                .Include(x => x.Lista_DetalleFactura)
                .Include(x => x.Objeto_Empleado)
                .Where(x => x.IdEmpleadoEnFactura == ID)
                .ToListAsync();

            return Objetos_Obtenido;
        }
    }
}
