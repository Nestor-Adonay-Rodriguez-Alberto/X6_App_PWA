using Acceso_Datos;
using Entidades;


namespace Logica_Negocio
{
    public class RolBL
    {
        // Objeto Representa DB:
        private readonly RolDAL _RolDAL;

        // Constructor:
        public RolBL(RolDAL rolDAL)
        {
            _RolDAL = rolDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Rol> Obtener_PorId(Rol rol)
        {
            return await _RolDAL.Obtener_PorId(rol);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Rol>> Obtener_Todos()
        {
            return await _RolDAL.Obtener_Todos();
        }


        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Rol rol)
        {
            return await _RolDAL.Create(rol);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Rol rol)
        {
            return await _RolDAL.Edit(rol);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Rol rol)
        {
            return await _RolDAL.Delete(rol);
        }

    }
}
