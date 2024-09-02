using Acceso_Datos;
using Entidades;

namespace Logica_Negocio
{
    public class EmpleadoBL
    {
        // Objeto Representa DB:
        private readonly EmpleadoDAL _EmpleadoDAL;

        // Constructor:
        public EmpleadoBL(EmpleadoDAL empleadoDAL)
        {
            _EmpleadoDAL = empleadoDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Empleado> Obtener_PorId(Empleado empleado)
        {
            return await _EmpleadoDAL.Obtener_PorId(empleado);
        }

        // Manda Todos Los Objetos:
        public async Task<List<Empleado>> Obtener_Todos()
        {
            return await _EmpleadoDAL.Obtener_Todos();
        }

        // Lista De La Tabla Roles Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            return await _EmpleadoDAL.Lista_Roles();
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Empleado empleado)
        {
            return await _EmpleadoDAL.Create(empleado);
        }

        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Empleado empleado)
        {
            return await _EmpleadoDAL.Edit(empleado);
        }

        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Empleado empleado)
        {
            return await _EmpleadoDAL.Delete(empleado);
        }
    }
}
