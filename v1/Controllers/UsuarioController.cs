using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}