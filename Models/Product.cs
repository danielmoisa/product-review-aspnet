namespace ProductReview.Models
{
    public class Product
    {
        public int Id { get; set; }
        // TODO: Add required field model level validation for ModelState handler
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ProductOwner> ProductOwners { get; set; } = new List<ProductOwner>();
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    }
}
