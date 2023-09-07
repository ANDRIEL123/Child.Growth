using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Child.Growth.src.Entities
{
    public class Users
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}