using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Dtos;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        public IActionResult GetProductById(int productId) {
            var productExists = _productRepository.ProductExist(productId);
            if (!productExists) return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(product);
        }

        [HttpGet("{productId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(404)]
        public IActionResult GetProductRating(int productId)
        {
            var productExists = _productRepository.ProductExist(productId);
            if (!productExists) return NotFound();

            var product = _productRepository.GetProductRating(productId);
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(product);
        }

    }
}
