using Logica_Negocio;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace P3_Maestro_Detalle.Controllers
{
    public class EmpleadosController : Controller
    {
        // Puente Para La DB:
        private readonly EmpleadoBL _EmpleadoBL;

        // Constructor:
        public EmpleadosController(EmpleadoBL empleadoBL)
        {
            _EmpleadoBL = empleadoBL;
        }


        // Manda Todos Los Registro De La DB:
        public async Task<IActionResult> Index()
        {
            var Objetos_Obtenidos = await _EmpleadoBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Manda Un Objeto Encontrado
        public async Task<IActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _EmpleadoBL.Obtener_PorId(new Empleado() { IdEmpleado = id });

            return View(Objeto_Obtenido);
        }


        // Manda La Lista De Los Registros De La Otra Tabla
        public async Task<IActionResult>Create()
        {
            var Lista_Roles = await _EmpleadoBL.Lista_Roles();

            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "IdRol", "Nombre");
           
            return View();
        }


        // Recibe Un Objeto Y Lo Guarda En La DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado, IFormFile Fotografia)
        {
            if (Fotografia != null && Fotografia.Length > 0)
            {

                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    empleado.Fotografia = memoryStream.ToArray();
                }
            }

            await _EmpleadoBL.Create(empleado);

            return RedirectToAction(nameof(Index));
        }


        // Mada Un Objeto Y Una Lista De La Otra Tabla
        public async Task<IActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _EmpleadoBL.Obtener_PorId(new Empleado() { IdEmpleado = id });

            var Lista_Roles = await _EmpleadoBL.Lista_Roles();

            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "IdRol", "Nombre",Objeto_Obtenido.IdRolEnEmpleado);

            return View(Objeto_Obtenido);
        }


        // Recibe Un Objeto Lo Busca Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empleado empleado, IFormFile Fotografia)
        {
            var Objeto_Obtenido = await _EmpleadoBL.Obtener_PorId(empleado);

            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    empleado.Fotografia = memoryStream.ToArray();
                }
            }
            else
            {
                empleado.Fotografia = Objeto_Obtenido.Fotografia;
            }

            await _EmpleadoBL.Edit(empleado);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto Encontrado
        public async Task<IActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _EmpleadoBL.Obtener_PorId(new Empleado() { IdEmpleado = id });

            return View(Objeto_Obtenido);
        }



        // Recibe Un Objeto Lo Busca Y Lo Elimina:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Empleado empleado)
        {
            await _EmpleadoBL.Delete(empleado);

            return RedirectToAction(nameof(Index));
        }

    }
}
