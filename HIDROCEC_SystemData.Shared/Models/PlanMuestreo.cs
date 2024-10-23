using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class PlanDeMuestreo
    {
        public int PlanMuestreoID { get; set; }
        public string NumeroCotizacion { get; set; }
        public DateTime FechaMuestreo { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public int CantidadMuestras { get; set; }
        public string ServiciosSolicitados { get; set; }

        // Claves foráneas
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int ResponsableMuestreoID { get; set; }
        public Usuario ResponsableMuestreo { get; set; }

        // Relaciones
        public ICollection<HojaDeCampo> HojasDeCampo { get; set; }
        public ICollection<IngresoLaboratorio> IngresosLaboratorio { get; set; }
    }

}
