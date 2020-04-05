using Microsoft.EntityFrameworkCore;
using Teste.BFF.v1.Models;

namespace Teste.BFF.EF {
    /// <summary>
    /// DbContext
    /// </summary>
    public class BancoDadosContext : DbContext {
        /// <summary>
        /// DbContext
        /// </summary>
        public BancoDadosContext (DbContextOptions options) : base (options) { }

        /// <summary>
        /// Tabela que contem os Usuarios;
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Tabela que contem os Sexos;
        /// </summary>
        public DbSet<Sexo> Sexos { get; set; }
    }
}