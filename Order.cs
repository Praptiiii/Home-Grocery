using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeGrocery.DAL.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        //public int Quantity { get; set; }
        //public int TotalCost { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
        public virtual User Users { get; set; } = null!;



        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public virtual Product Products { get; set; } = null!;

    }
}
