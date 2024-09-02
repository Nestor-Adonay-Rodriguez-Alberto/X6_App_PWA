using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class DetalleFactura
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalle { get; set; }

        [Required(ErrorMessage ="Nombre Del Producto A LLevar.")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "Cantidad A LLevar.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Precido Del Producto.")]
        public decimal Precio { get; set; } 


        // Referencia Tabla Factura:
        [ForeignKey("Objeto_Factura")]
        public int IdFacturaEnDetalle { get; set; }
        public virtual Factura Objeto_Factura { get; set; }
    }
}
