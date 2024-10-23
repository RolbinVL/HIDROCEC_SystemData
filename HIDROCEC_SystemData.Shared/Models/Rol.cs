using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class Rol
    {
        public int RolID { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<Usuario> Usuarios { get; set; }
    }

}
