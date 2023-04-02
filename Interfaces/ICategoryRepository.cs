using ProductReview.Models;

namespace ProductReview.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int id);
        ICollection<Product> GetProductByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
