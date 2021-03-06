using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Teste.BFF.EF;
using Teste.BFF.v1.Models;

namespace Teste.BFF.v1.Services {
    /// <summary>
    /// Interface User Service
    /// </summary>
    public interface IUsuarioService {
        /// <summary>
        /// Add
        /// </summary>
        void Add<T> (T entity) where T : class;

        /// <summary>
        /// Update
        /// </summary>
        void Update<T> (T entity) where T : class;

        /// <summary>
        /// Delete
        /// </summary>
        void Delete<T> (T entity) where T : class;

        /// <summary>
        /// Save
        /// </summary>
        Task<bool> SaveChangesAsync ();

        /// <summary>
        /// Get Users
        /// </summary>
        Task<IEnumerable<object>> GetAllUsersAsync ();

        /// <summary>
        /// GetUserById
        /// </summary>
        Task<Usuario> GetUserByIdAsync (int id);

        /// <summary>
        /// Get Users
        /// </summary>
        Task<Usuario[]> GetUsuariosAtivos (string ativo);

    }
    /// <summary>
    /// Classe UserService
    /// </summary>
    public class UsuarioService : IUsuarioService {

        /// <summary>
        /// IntegradorSaudeBDContext
        /// </summary>
        private readonly BancoDadosContext _context;

        /// <summary>
        /// IntegradorSaudeBDContext
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// IntegradorSaudeBDContext
        /// </summary>
        public UsuarioService (BancoDadosContext context, IConfiguration configuration) {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _configuration = configuration;
        }

        /// <summary>
        /// Add
        /// </summary>
        public void Add<T> (T entity) where T : class {
            _context.Add (entity);
        }
        /// <summary>
        /// Update
        /// </summary>
        public void Update<T> (T entity) where T : class {
            _context.Update (entity);
        }
        /// <summary>
        /// Delete
        /// </summary>
        public void Delete<T> (T entity) where T : class {
            _context.Remove (entity);
        }

        /// <summary>
        ///Save
        /// </summary>
        public async Task<bool> SaveChangesAsync () {
            return (await _context.SaveChangesAsync ()) > 0;
        }

        /// <summary>
        ///GetUsers
        /// </summary>
        public async Task<IEnumerable<object>> GetAllUsersAsync () {
            var query = await (from u in _context.Usuarios join s in _context.Sexos on u.SexoId equals s.SexoId select new {
                    userId = u.UserId,
                        nome = u.Nome,
                        dataNascimento = u.DataNascimento,
                        email = u.Email,
                        sexoId = s.Descricao,
                        ativo = u.Ativo
                }).OrderBy (f => f.userId)
                .ToArrayAsync ();
            return query;
        }

        /// <summary>
        ///GetUserAsyncByEmail
        /// </summary>
        public async Task<Usuario[]> GetUsuariosAtivos (string ativo) {
            IQueryable<Usuario> query = _context.Usuarios;
            bool filtro = true;
            if (ativo != "Ativo") {
                filtro = false;
            }
            query = query.AsNoTracking ()
                .Where (c => c.Ativo == filtro)
                .OrderBy (c => c.UserId);
            return await query.ToArrayAsync ();
        }

        /// <summary>
        ///GetUserAsyncByID
        /// </summary>
        public async Task<Usuario> GetUserByIdAsync (int id) {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking ()
                .Where (c => c.UserId == id);
            return await query.FirstOrDefaultAsync ();
        }
    }
}