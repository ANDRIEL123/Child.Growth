using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Crianças
    /// </summary>
    public class Children : EntityBase
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        [Column("active")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Imagem de perfil
        /// </summary>
        [Column("avatar")]
        public string Avatar { get; set; }
    }
}