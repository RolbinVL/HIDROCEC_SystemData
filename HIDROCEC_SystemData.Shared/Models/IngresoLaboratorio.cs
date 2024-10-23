using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class IngresoLaboratorio
    {
        public int IngresoLaboratorioID { get; set; }
        public int CantidadContenedoresRecibidos { get; set; }
        public string CodigoGenerado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string FirmaQuienIngresa { get; set; }
        public string FirmaQuienRecibe { get; set; }

        // Claves foráneas
        public int PlanMuestreoID { get; set; }
        public PlanDeMuestreo PlanDeMuestreo { get; set; }

        public int ResponsableIngresoID { get; set; }
        public Usuario ResponsableIngreso { get; set; }

        public int? ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }

}
