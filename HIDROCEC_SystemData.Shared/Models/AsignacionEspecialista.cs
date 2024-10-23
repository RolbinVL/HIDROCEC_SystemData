using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class AsignacionEspecialista
    {
        public int AsignacionID { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Claves foráneas
        public int IngresoLaboratorioID { get; set; }
        public IngresoLaboratorio IngresoLaboratorio { get; set; }

        public int EspecialistaID { get; set; }
        public Usuario Especialista { get; set; }
    }

}
