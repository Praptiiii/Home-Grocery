using System.ComponentModel.DataAnnotations;

namespace HomeGrocery.BLL.DTO
{
    public class UserDTO
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
