using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Representante { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string OtrasSenales { get; set; }
        public string SitiosDeMuestreo { get; set; }

        // Relaciones
        public ICollection<PlanDeMuestreo> PlanesDeMuestreo { get; set; }
    }

}
