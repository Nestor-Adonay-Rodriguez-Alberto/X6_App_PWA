using Acceso_Datos;
using Entidades;

namespace Logica_Negocio
{
    public class FacturaBL
    {
        // Objeto Representa DB:
        private readonly FacturaDAL _FacturaDAL;

        // Constructor:
        public FacturaBL(FacturaDAL facturaDAL)
        {
            _FacturaDAL = facturaDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Factura> Obtener_PorId(Factura factura)
        {
            return await _FacturaDAL.Obtener_PorId(factura);
        }

        // Manda Todos Los Objetos:
        public async Task<List<Factura>> Obtener_Todos()
        {
            return await _FacturaDAL.Obtener_Todos();
        }

        // Lista De La Tabla Empleado Para ViewData:
        public async Task<List<Empleado>> Lista_Empleados()
        {
            return await _FacturaDAL.Lista_Empleados();
        }



        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Factura factura)
        {
            return await _FacturaDAL.Create(factura);
        }

        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Factura factura)
        {
            return await _FacturaDAL.Edit(factura);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Factura factura)
        {
            return await _FacturaDAL.Delete(factura);
        }
    }
}
