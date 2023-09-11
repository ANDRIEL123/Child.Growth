using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Usuários
    /// </summary>
    public class Users : EntityBase
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Tipo de usuário
        /// </summary>
        [Column("type")]
        public short Type { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        [Column("active")]
        public short Active { get; set; }

        /// <summary>
        /// Telefone/Celular
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Column("password")]
        public string Password { get; set; }
    }
}