using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Acceso_Datos
{
    public class EmpleadoDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public EmpleadoDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Empleado> Obtener_PorId(Empleado empleado)
        {
            var Objeto_Obtenido = await _MyDBcontext.Empleados
                .Include(x => x.Objeto_Rol)
                .FirstOrDefaultAsync(x => x.IdEmpleado == empleado.IdEmpleado);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Empleado>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Empleados
                .Include(x => x.Objeto_Rol)
                .ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Roles Para ViewData:
        public async Task<List<Rol>> Lista_Roles()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Roles.ToListAsync();

            return Objetos_Obtenidos;
        }


        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Empleado empleado)
        {
            _MyDBcontext.Add(empleado);

            return await _MyDBcontext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Empleado empleado)
        {
            var Objeto_Obtenido = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == empleado.IdEmpleado);

            if(Objeto_Obtenido!=null)
            {
                Objeto_Obtenido.Nombre = empleado.Nombre;
                Objeto_Obtenido.Sueldo = empleado.Sueldo;
                Objeto_Obtenido.Fotografia = empleado.Fotografia;
                Objeto_Obtenido.IdRolEnEmpleado = empleado.IdRolEnEmpleado;

                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Empleado empleado)
        {
            var Objeto_Obtenido = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == empleado.IdEmpleado);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }

    }
}
