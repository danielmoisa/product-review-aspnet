namespace ProductReview.Models
{
    public class ProductCategory
    {
        public int ProductId{ get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; } = new Product();
        public Category Category { get; set; } = new Category();

    }
}
