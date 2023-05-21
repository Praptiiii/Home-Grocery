using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HomeGrocery.DAL.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual ICollection<Role> Role { get; set; } = null!;
        public virtual Order Orders { get; set; } = null!;
    }
}
