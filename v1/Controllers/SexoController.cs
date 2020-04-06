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
    public class SexoController : ControllerBase {

        /// <summary>
        /// Context
        /// </summary>
        public readonly ISexoService _repo;

        /// <summary>
        /// context
        /// </summary>
        public SexoController (ISexoService repo) {
            _repo = repo;
        }

        /// <summary>
        /// Get Sexos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var results = await _repo.GetAllSexosAsync ();
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
                var results = await _repo.GetSexoByIdAsync (id);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error1");
            }
        }

        /// <summary>
        /// Post Sexos
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post (Sexo model) {
            try {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/v1/Sexo/GetById/{model.SexoId}", model);
                }
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Database error");
            }
            return BadRequest ();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete (int sexoId) {
            try {
                var sexo = _repo.GetSexoByIdAsync (sexoId);

                if (sexo == null) return NotFound ();
                _repo.Delete (sexo);

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