using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Acceso_Datos
{
    public class RolDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public RolDAL(MyDBcontext myDBcontext)
        {
             _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Rol> Obtener_PorId(Rol rol)
        {
            var Objeto_Obtenido = await _MyDBcontext.Roles.FirstOrDefaultAsync(x=> x.IdRol== rol.IdRol);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Rol>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Roles.ToListAsync();

            return Objetos_Obtenidos;
        }


        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Rol rol)
        {
            _MyDBcontext.Add(rol);

            return await _MyDBcontext.SaveChangesAsync();
        }

        
        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Rol rol)
        {
            var Objeto_Obtenido = await _MyDBcontext.Roles.FirstOrDefaultAsync(x=> x.IdRol == rol.IdRol);

            if(Objeto_Obtenido!=null)
            {
                Objeto_Obtenido.Nombre = rol.Nombre;

                _MyDBcontext.Update(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }

        
        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Rol rol)
        {
            var Objeto_Obtenido = await _MyDBcontext.Roles.FirstOrDefaultAsync(x => x.IdRol == rol.IdRol);

            if(Objeto_Obtenido!=null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }
    }
}
