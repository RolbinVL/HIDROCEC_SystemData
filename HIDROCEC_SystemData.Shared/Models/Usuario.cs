using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIDROCEC_SystemData.Shared.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string? Telefono { get; set; } 
        public string? Contraseña { get; set; }

        // Clave foránea
        public int RolID { get; set; }
        public Rol? Rol { get; set; }

        // Relaciones
        public ICollection<PlanDeMuestreo> PlanesDeMuestreo { get; set; }
        public ICollection<HojaDeCampo> HojasDeCampo { get; set; }
        public ICollection<IngresoLaboratorio> IngresosLaboratorio { get; set; }
        public ICollection<AsignacionEspecialista> Asignaciones { get; set; }
    }

}
