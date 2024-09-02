using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Acceso_Datos
{
    public class FacturaDAL
    {
        // Representa DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public FacturaDAL(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Factura> Obtener_PorId(Factura factura)
        {
            var Objeto_Obtenido = await _MyDBcontext.Facturas
                .Include(f => f.Objeto_Empleado)
                .Include(f => f.Lista_DetalleFactura)
                .FirstOrDefaultAsync(m => m.IdFactura == factura.IdFactura);


            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos:
        public async Task<List<Factura>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Facturas.Include(f => f.Objeto_Empleado).ToListAsync();

            return Objetos_Obtenidos;
        }

        // Lista De La Tabla Empleado Para ViewData:
        public async Task<List<Empleado>> Lista_Empleados()
        {
            var Objetos_Obtenidos = await _MyDBcontext.Empleados.ToListAsync();

            return Objetos_Obtenidos;
        }



        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Create(Factura factura)
        {
            _MyDBcontext.Add(factura);

            return await _MyDBcontext.SaveChangesAsync();
        }

        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Factura factura)
        {
            var Objeto_Obtenido = await _MyDBcontext.Facturas
                .Include(f => f.Objeto_Empleado)
                .Include(f => f.Lista_DetalleFactura)
                .FirstOrDefaultAsync(m => m.IdFactura == factura.IdFactura);

            if (Objeto_Obtenido != null)
            {
                // Modificamos Los Atributos
                Objeto_Obtenido.Fecha = factura.Fecha;
                Objeto_Obtenido.Correlativo = factura.Correlativo;
                Objeto_Obtenido.IdEmpleadoEnFactura = factura.IdEmpleadoEnFactura;
                Objeto_Obtenido.Cliente = factura.Cliente;
                Objeto_Obtenido.Total = factura.Total;




                // Agregar Los Nuevos Objetos A La Lista:
                var Filas_Nuevas = factura.Lista_DetalleFactura.Where(s => s.IdDetalle == 0);
                foreach (var Fila in Filas_Nuevas)
                {

                    Objeto_Obtenido.Lista_DetalleFactura.Add(Fila);
                }


                // Objetos Ya Existente De La Lista  "Podrian Traer Cambios"
                var Objetos_Lista = factura.Lista_DetalleFactura.Where(s => s.IdDetalle > 0);
                foreach (var Fila in Objetos_Lista)
                {
                    //Objeto De La Lista A Modificar
                    var Objeto_DeList = Objeto_Obtenido.Lista_DetalleFactura.FirstOrDefault(s => s.IdDetalle == Fila.IdDetalle);

                    Objeto_DeList.Producto = Fila.Producto;
                    Objeto_DeList.Cantidad = Fila.Cantidad;
                    Objeto_DeList.Precio = Fila.Precio;

                }


                // ELIMINA FILAS DEL DETALLE
                var Filas_Eliminar = factura.Lista_DetalleFactura.Where(s => s.IdDetalle < 0).ToList();

                if (Filas_Eliminar != null && Filas_Eliminar.Count > 0)
                {
                    foreach (var Fila in Filas_Eliminar)
                    {
                        Fila.IdDetalle = Fila.IdDetalle * -1;

                        var Objeto_Lista = Objeto_Obtenido.Lista_DetalleFactura.FirstOrDefault(s => s.IdDetalle == Fila.IdDetalle);

                        _MyDBcontext.Remove(Objeto_Lista);
                        await _MyDBcontext.SaveChangesAsync();
                    }
                }


                _MyDBcontext.Update(Objeto_Obtenido);
            }

            //Recalcular 
            Objeto_Obtenido.Total = Objeto_Obtenido.Lista_DetalleFactura.Sum(s => s.Cantidad * s.Precio);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Factura factura)
        {
            var Objeto_Obtenido = await _MyDBcontext.Facturas
                .Include(f => f.Objeto_Empleado)
                .Include(f => f.Lista_DetalleFactura)
                .FirstOrDefaultAsync(m => m.IdFactura == factura.IdFactura);

            if(Objeto_Obtenido!=null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
            }

            return await _MyDBcontext.SaveChangesAsync();
        }
    }
}
