using ProductReview.Data;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetProductRating(int id)
        {
            var review = _context.Reviews.Where(p => p.Product.Id == id);
            if(review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
