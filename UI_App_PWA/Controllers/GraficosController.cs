using Logica_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace UI_Graficos_Barra_Pastel.Controllers
{
    public class GraficosController : Controller
    {
        // Puente Entre DB:
        private readonly FacturaBL _FacturaBL;

        // Constructor:
        public GraficosController(FacturaBL facturaBL)
        {
            _FacturaBL = facturaBL;
        }



        // Me Manda A Vista De Google Charts
        public IActionResult GraficoPorVentas()
        {
            return View();
        }


        //Lo Invocan Y Manda Un Json de Lista de Objets
        public async Task<ActionResult> GetInfoVentas()
        {

            // Todas Las Facturas:
            var Objetos_Obtenidos = await _FacturaBL.Obtener_Todos();

            // Agrupamos Las De Cada Empleado
            var Empleado_Nestor = Objetos_Obtenidos.Where(x => x.Objeto_Empleado.Nombre == "Nestor Adonay Rodriguez Alberto");
            var Empleado_Jose = Objetos_Obtenidos.Where(x => x.Objeto_Empleado.Nombre == "José Manuel Renderos Hernández");
            var Empleado_Maribel = Objetos_Obtenidos.Where(x => x.Objeto_Empleado.Nombre == "Karla Maribel Lopez");

            
            var Lista_Ventas = new List<object>();

            Lista_Ventas.Add(new
            {
                grupo = "Nestor Adonay Rodriguez Alberto",
                cantidad = Empleado_Nestor.Count(),
            });

            Lista_Ventas.Add(new
            {
                grupo = "José Manuel Renderos Hernández",
                cantidad = Empleado_Jose.Count(),
            });

            Lista_Ventas.Add(new
            {
                grupo = "Karla Maribel Lopez",
                cantidad = Empleado_Maribel.Count(),
            });

            return Json(Lista_Ventas);
        }
    }
}
