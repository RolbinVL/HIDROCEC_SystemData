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
    public class UsuarioController : ControllerBase
    {
        #region Context
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Pruebas

        [HttpGet("ConexionServidor")]
        public async Task<ActionResult<string>> GetEjemplo()
        {
            return "conectado con el servidor";
        }

        [HttpGet("ConexionUsuario")]
        public async Task<ActionResult<string>> GetConexionUsuario()
        {
            try
            {
                var respuesta = await _context.Usuario.ToListAsync();
                return "Conectado a la base de datos, tabla Usuario";
            }
            catch (Exception ex)
            {
                return "Error de Conexion con Usuario";
            }

        }

        #endregion

        #region CRUD
        // Obtener todos los usuarios (READ)
        [HttpGet("ObtenerUsuarios")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _context.Usuario.ToListAsync();
                return usuarios;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios: " + ex.Message);
            }
        }

        // Obtener un usuario por ID (READ)
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return usuario;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario: " + ex.Message);
            }
        }

        // Crear un nuevo usuario (CREATE)
        [HttpPost("NuevoUsuario")]
        public async Task<ActionResult<string>> CreateUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return "Usuario guardado con éxito en HIDROCEC_SystemData";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar el usuario: " + ex.Message);
            }
        }

        // Actualizar un usuario (UPDATE)
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateUsuario(int id, Usuario usuarioActualizado)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                // Actualizamos los datos del usuario
                usuario.NombreUsuario = usuarioActualizado.NombreUsuario;
                usuario.CorreoElectronico = usuarioActualizado.CorreoElectronico;
                usuario.Telefono = usuarioActualizado.Telefono;
                usuario.Contraseña = usuarioActualizado.Contraseña;
                usuario.RolID = usuarioActualizado.RolID;

                await _context.SaveChangesAsync();
                return "Usuario actualizado con éxito";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario: " + ex.Message);
            }
        }

        // Eliminar un usuario (DELETE)
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return "Usuario eliminado con éxito";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario: " + ex.Message);
            }
        }

        #endregion

    }
}
