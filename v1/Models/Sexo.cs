using System.ComponentModel.DataAnnotations;

namespace Teste.BFF.v1.Models {
    /// <summary>
    /// Classe de Sexos
    /// </summary>
    public class Sexo {

        /// <summary>
        /// Id do Sexo
        /// </summary>
        [Key]
        public int SexoId { get; set; }

        /// <summary>
        /// //Descricao do Sexo com tamanho maximo de 15 caracteres;
        /// </summary>
        [StringLength (15)]
        public string Descricao { get; set; }
    }
}