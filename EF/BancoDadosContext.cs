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
        /// Tabela que contem as colunas de acordo com Layout, Tipo de Registro, etc...
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}