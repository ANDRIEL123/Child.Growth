using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;
using Child.Growth.src.Infra.Enums;

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
        public UserTypeEnum Type { get; set; } = UserTypeEnum.Doctor;

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        [Column("active")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// Telefone/Celular
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Imagem de perfil do usuário
        /// </summary>
        [Column("avatar")]
        public string Avatar { get; set; }

        #region Collections

        public virtual ICollection<Responsible> Responsible { get; set; }

        #endregion
    }
}