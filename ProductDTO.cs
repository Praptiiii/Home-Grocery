namespace HomeGrocery.BLL.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string Imageurl { get; set; } = null!;
    }
}
