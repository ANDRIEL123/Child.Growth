using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Responsáveis
    /// </summary>
    public class Responsible : EntityBase
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Column("cpf")]
        public string Cpf { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        [Column("birthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Id do usuário
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }

        #region References

        public virtual Users User { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Children> Children { get; set; }

        #endregion
    }
}