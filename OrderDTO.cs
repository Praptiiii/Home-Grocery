using System.ComponentModel.DataAnnotations;

namespace HomeGrocery.BLL.DTO
{
    public class OrderDTO
    {
        [Key]
        public int OrderID { get; set; }
        //public int Quantity { get; set; }
        //public int TotalCost { get; set; }
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
