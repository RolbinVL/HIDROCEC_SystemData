using HIDROCEC_SystemData.Server.Data;
using HIDROCEC_SystemData.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using HIDROCEC_SystemData.Shared.Models;

namespace HIDROCEC_SystemData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Verificación de conexión con el servidor
        [HttpGet("ConexionServidor")]
        public async Task<ActionResult<string>> GetConexionServidor()
        {
            return "Conectado con el servidor para HIDROCEC_SystemData";
        }

        // Verificación de conexión con la tabla Roles
        [HttpGet("ConexionRol")]
        public async Task<ActionResult<string>> GetConexionRol()
        {
            try
            {
                var respuesta = await _context.Rols.ToListAsync();
                return "Conectado a la base de datos, tabla Roles del sistema HIDROCEC_SystemData";
            }
            catch (Exception ex)
            {
                return "Error de conexión con la tabla Roles";
            }
        }

        // Obtener todos los roles (READ)
        [HttpGet("ObtenerRoles")]
        public async Task<ActionResult<List<Rol>>> GetRoles()
        {
            try
            {
                var roles = await _context.Rols.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los roles: " + ex.Message);
            }
        }

        // Obtener un rol por ID (READ)
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            try
            {
                var rol = await _context.Rols.FindAsync(id);

                if (rol == null)
                {
                    return NotFound("Rol no encontrado");
                }

                return rol;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el rol: " + ex.Message);
            }
        }

        // Crear un nuevo rol (CREATE)
        [HttpPost("NuevoRol")]
        public async Task<ActionResult<string>> CreateRol(Rol rol)
        {
            try
            {
                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();
                return "Rol guardado con éxito en HIDROCEC_SystemData";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar el rol: " + ex.Message);
            }
        }

        // Actualizar un rol (UPDATE)
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateRol(int id, Rol rolActualizado)
        {
            try
            {
                var rol = await _context.Rols.FindAsync(id);

                if (rol == null)
                {
                    return NotFound("Rol no encontrado");
                }

                // Actualizamos los datos del rol
                rol.NombreRol = rolActualizado.NombreRol;
                rol.Descripcion = rolActualizado.Descripcion;

                await _context.SaveChangesAsync();
                return "Rol actualizado con éxito";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el rol: " + ex.Message);
            }
        }

        // Eliminar un rol (DELETE)
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteRol(int id)
        {
            try
            {
                var rol = await _context.Rols.FindAsync(id);

                if (rol == null)
                {
                    return NotFound("Rol no encontrado");
                }

                _context.Rols.Remove(rol);
                await _context.SaveChangesAsync();
                return "Rol eliminado con éxito";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el rol: " + ex.Message);
            }
        }
    }
}

