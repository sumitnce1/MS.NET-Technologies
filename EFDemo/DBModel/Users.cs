using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DBModel
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Column("MobileNumber")]
        [MaxLength(15)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string UserType { get; set; }
    }
}
