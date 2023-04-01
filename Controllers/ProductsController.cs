using Microsoft.AspNetCore.Mvc;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))] 
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);
        }
    }
}
