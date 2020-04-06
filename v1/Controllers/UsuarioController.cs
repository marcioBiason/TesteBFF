using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.BFF.v1.Models;
using Teste.BFF.v1.Services;

namespace TesteBFF.v1.Controllers {
    /// <summary>
    /// Controller de Usuarios;
    /// </summary>
    [ApiVersion ("1.0")]
    [ApiController]
    [Route ("v{version:apiVersion}/[controller]")]
    public class UsuarioController : ControllerBase {

        /// <summary>
        /// Context
        /// </summary>
        public readonly IUsuarioService _repo;

        /// <summary>
        /// context
        /// </summary>
        public UsuarioController (IUsuarioService repo) {
            _repo = repo;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var results = await _repo.GetAllUsersAsync ();
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        /// <summary>
        /// Get UsuariosById
        /// </summary>
        [HttpGet ("GetById/{id}")]
        public async Task<IActionResult> GetId (int id) {
            try {
                var results = await _repo.GetUserByIdAsync (id);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        /// <summary>
        /// Get UsuariosById
        /// </summary>
        [HttpGet ("GetUsuariosAtivos/{ativo}")]
        public async Task<IActionResult> GetUsuariosAtivos (string ativo) {
            try {
                var results = await _repo.GetUsuariosAtivos (ativo);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        /// <summary>
        /// Post Usuario
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post (Usuario model) {
            try {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/v1/Usuario/GetById/{model.UserId}", model);
                }
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
            return BadRequest ();
        }

        /// <summary>
        /// Put Usuario
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put (int id, Usuario model) {
            try {

                var usuario = await _repo.GetUserByIdAsync (id);
                if (usuario == null) return NotFound ();

                _repo.Update (model);

                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/v1/Usuario/GetById/{model.UserId}", model);
                }
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
            return BadRequest ();
        }

        /// <summary>
        /// Put Usuario
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete (int id) {
            try {

                var usuario = await _repo.GetUserByIdAsync (id);
                if (usuario == null) return NotFound ();

                _repo.Delete (usuario);

                if (await _repo.SaveChangesAsync ()) {
                    return Ok ();
                }
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
            return BadRequest ();
        }

    }
}