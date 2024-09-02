using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Rol
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Required(ErrorMessage ="Nombre Del Rol.")]
        public string Nombre { get; set; }

        // Tabla Empleado Asociada A Esta:
        public virtual List<Empleado> Lista_Empleados { get; set; }



        // Constructor:
        public Rol()
        {
            Lista_Empleados = new List<Empleado>();
        }
    }
}
