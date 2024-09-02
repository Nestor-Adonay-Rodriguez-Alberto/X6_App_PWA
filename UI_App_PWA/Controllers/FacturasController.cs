using Logica_Negocio;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace P3_Maestro_Detalle.Controllers
{
    public class FacturasController : Controller
    {
        // Puente Para La DB:
        private readonly FacturaBL _FacturaBL;


        // Constructor:
        public FacturasController(FacturaBL facturaBL)
        {
            _FacturaBL = facturaBL;
        }


        // Manda Todos Los Registros De La Tabla
        public async Task<IActionResult> Index()
        {
            var Objetos_Obtenidos = await _FacturaBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Manda Un Objeto Encontrado
        public async Task<IActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _FacturaBL.Obtener_PorId(new Factura() { IdFactura=id});

            ViewBag.Accion = "Details";

            return View(Objeto_Obtenido);
        }


        // Manda Una Lista De Una Tabla Para Seleccionar
        public async Task<IActionResult> Create()
        {
            // Todos Los Registros
            var Objetos_Obtenido = await _FacturaBL.Obtener_Todos();
            var NCorrelativos = Objetos_Obtenido.Count;

            // Creamos Un Objeto Y A Su Lista Agregamos Info:
            Factura Objeto_Inicio = new Factura();


            Objeto_Inicio.Fecha = DateTime.Now.Date;
            Objeto_Inicio.Correlativo = NCorrelativos + 1;

            // Lista
            Objeto_Inicio.Lista_DetalleFactura = new List<DetalleFactura>();
            Objeto_Inicio.Lista_DetalleFactura.Add(
                new DetalleFactura
                {
                    Cantidad = 1,
                    Precio = 0
                }
                );

            var Lista_Empleados = await _FacturaBL.Lista_Empleados();

            ViewData["Lista_Empleados"] = new SelectList(Lista_Empleados, "IdEmpleado", "Nombre");
           
            ViewBag.Accion = "Create";

            return View(Objeto_Inicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Factura factura)
        {
            factura.Total = factura.Lista_DetalleFactura.Sum(x => x.Cantidad * x.Precio);

            await _FacturaBL.Create(factura);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto Encontrado
        public async Task<IActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _FacturaBL.Obtener_PorId(new Factura() { IdFactura = id });

            var Lista_Empleados = await _FacturaBL.Lista_Empleados();

            ViewData["Lista_Empleados"] = new SelectList(Lista_Empleados, "IdEmpleado", "Nombre", Objeto_Obtenido.IdEmpleadoEnFactura);

            ViewBag.Accion = "Edit";

            return View(Objeto_Obtenido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Factura factura)
        {
            await _FacturaBL.Edit(factura);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto Encontrado:
        public async Task<IActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _FacturaBL.Obtener_PorId(new Factura() { IdFactura = id });

            ViewBag.Accion = "Delete";

            return View(Objeto_Obtenido);
        }

        // POST: Facturas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Factura factura)
        {
            await _FacturaBL.Delete(factura);

            return RedirectToAction(nameof(Index));
        }


        // **********************************************************************
        // Para Agregar Y Eliminar Filas Del Detalle:
        [HttpPost]
        public async Task<ActionResult> Agregar_Fila(Factura factura, string accion)
        {
            //Agregamos Objeto A La Lista
            factura.Lista_DetalleFactura.Add(new DetalleFactura
            {
                Cantidad = 1,
                Precio = 0
            });

            var Lista_Empleados = await _FacturaBL.Lista_Empleados();
            ViewData["Lista_Empleados"] = new SelectList(Lista_Empleados, "IdEmpleado", "Nombre", factura.IdEmpleadoEnFactura);

            ViewBag.Accion = accion;
            return View(accion, factura);
        }


        public async Task<ActionResult> Eliminar_Fila(Factura factura,int index, string accion)
        {
            var Objeto_Obtenido = factura.Lista_DetalleFactura[index];

            if (accion == "Edit" && Objeto_Obtenido.IdDetalle > 0)
            {
                Objeto_Obtenido.IdDetalle = Objeto_Obtenido.IdDetalle * -1;
            }
            else
            {
                factura.Lista_DetalleFactura.RemoveAt(index);
            }

            factura.Total = factura.Lista_DetalleFactura.Sum(s => s.Cantidad * s.Precio);

            var Lista_Empleados = await _FacturaBL.Lista_Empleados();
            ViewData["Lista_Empleados"] = new SelectList(Lista_Empleados, "IdEmpleado", "Nombre", factura.IdEmpleadoEnFactura);

            ViewBag.Accion = accion;

            return View(accion, factura);
        }


    }
}
