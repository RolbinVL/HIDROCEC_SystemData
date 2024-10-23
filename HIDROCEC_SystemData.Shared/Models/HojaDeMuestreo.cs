using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class HojaDeCampo
    {
        public int HojaCampoID { get; set; }
        public DateTime FechaMuestreo { get; set; }
        public string TipoMuestreo { get; set; }
        public string CodigoGenerado { get; set; }
        public float? TemperaturaConservacion { get; set; }
        public TimeSpan? HoraMuestreo { get; set; }
        public TimeSpan? HoraConservacion { get; set; }
        public float? PH { get; set; }
        public float? CE { get; set; }
        public float? CloroResid { get; set; }
        public float? Turbiedad { get; set; }
        public float? OD { get; set; }
        public float? PorcentajeSaturacionOxigeno { get; set; }
        public float? SolidosTotalesDisueltos { get; set; }
        public float? Salinidad { get; set; }
        public string ContenedoresUtilizados { get; set; }
        public string Justificacion { get; set; }
        public string FirmaMuestreador { get; set; }
        public string FirmaCliente { get; set; }

        // Claves foráneas
        public int PlanMuestreoID { get; set; }
        public PlanDeMuestreo PlanDeMuestreo { get; set; }

        public int MuestreadorID { get; set; }
        public Usuario Muestreador { get; set; }
    }

}
