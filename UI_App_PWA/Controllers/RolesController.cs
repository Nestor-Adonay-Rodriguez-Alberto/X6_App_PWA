
using Microsoft.AspNetCore.Mvc;
using Logica_Negocio;
using Entidades;

namespace UI_Maestro_Detalle.Controllers
{
    public class RolesController : Controller
    {
        // Puente Para La DB:
        private readonly RolBL _RolBL;

        // Constructor:
        public RolesController(RolBL rolBL)
        {
            _RolBL = rolBL;
        }


        // Manda Todos Los Registros De La DB:
        public async Task<IActionResult> Index()
        {
            var Objetos_Obtenidos = await _RolBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto Encontrado
        public async Task<IActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }

        public IActionResult Create()
        {
            return View();
        }


        // Recibe Un Objeto Y Lo Guarda En La DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol rol)
        {
            await _RolBL.Create(rol);

            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }


        // Recibe Un Objeto Lo Busca En La DB Y Modifica El De La DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Rol rol)
        {
            await _RolBL.Edit(rol);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto 
        public async Task<IActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { IdRol = id });

            return View(Objeto_Obtenido);
        }


        // Recibe Un Objeto Lo Busca En La DB Y lLo Elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Rol rol)
        {
            await _RolBL.Delete(rol);

            return RedirectToAction(nameof(Index));
        }

    }
}
