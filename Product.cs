using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HomeGrocery.DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string Imageurl { get; set; } = null!;
        public virtual Order Orders { get; set; } = null!;




    }
}
