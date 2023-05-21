using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HomeGrocery.DAL.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; } = null!;
    }
}
