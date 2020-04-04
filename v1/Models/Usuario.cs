using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teste.v1.Models;

namespace Teste.BFF.v1.Models {

    /// <summary>
    /// Classe de Usuarios
    /// </summary>
    public class Usuario {

        /// <summary>
        /// Id do usuario
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Usuario Ativo
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Sexo do Usuario
        /// </summary>
        public int SexoId { get; set; }

        /// <summary>
        /// Id do File
        /// </summary>
        [ForeignKey ("SexoId")]
        public Sexo Sexo { get; set; }
    }
}