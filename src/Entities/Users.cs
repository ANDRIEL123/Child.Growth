using System.ComponentModel.DataAnnotations.Schema;

namespace Child.Growth.src.Entities
{
    public class Users
    {
        /// <summary>
        /// Identificador
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
        /// Hash do password
        /// </summary>
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Salt do password
        /// </summary>
        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Criado em
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Modificado em
        /// </summary>
        [Column("modified_at")]
        public DateTime? ModifiedAt { get; set; }
    }
}