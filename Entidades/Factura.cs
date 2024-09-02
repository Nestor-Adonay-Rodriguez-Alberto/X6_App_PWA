using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Factura
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFactura { get; set; } 

        [Required(ErrorMessage ="Ingrese La Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage ="Correlativo De La Factura.")]
        public int Correlativo { get; set; }

        [Required(ErrorMessage ="Nombre Del Cliente.")]
        public string Cliente { get; set; }

        public decimal Total { get; set; }

        // Tabla DetalleFcatura Asociada A Esta:
        public virtual List<DetalleFactura> Lista_DetalleFactura { get; set; }



        // Referencia Tabla Empleado:
        [ForeignKey("Objeto_Empleado")]
        public int IdEmpleadoEnFactura { get; set; }
        public virtual Empleado Objeto_Empleado { get; set; }



        // Constructor:
        public Factura()
        {
            Lista_DetalleFactura = new List<DetalleFactura>();
        }
    }
}
