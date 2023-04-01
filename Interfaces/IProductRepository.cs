using ProductReview.Models;

namespace ProductReview.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}
