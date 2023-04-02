using ProductReview.Data;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.ProductCategories.Where(c => c.CategoryId == categoryId).Select(c => c.Product).ToList();
        }
    }
}
