using ProductReview.Models;

namespace ProductReview.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        decimal GetProductRating(int id);
        bool ProductExists(int id);
    }
}
