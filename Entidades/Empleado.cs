using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Empleado
    {
        // Atribututos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }


        [Required(ErrorMessage ="Debe Ingresar El Nombre.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Debe Ingresar El Salario.")]
        public decimal Sueldo { get; set; }


        public byte[]? Fotografia { get; set; }


        // Tabla Factura Asociada A Esta:
        public virtual List<Factura> Lista_Facturas { get; set; }



        // Referencia Tabla Rol:
        [ForeignKey("Objeto_Rol")]
        public int IdRolEnEmpleado { get; set; }
        public virtual Rol Objeto_Rol { get; set; }


        // Constructor:
        public Empleado()
        {
            Lista_Facturas = new List<Factura>();
        }
    }
}
