namespace ProductReview.Models
{
    public class ProductOwner
    {
        public int ProductId { get; set; }
        public int OwnerId { get; set; }
        public Product Product { get; set; } = new Product();   
        public Owner Owner { get; set; } = new Owner(); 
    }
}
