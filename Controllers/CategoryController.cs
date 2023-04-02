using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Dtos;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(404)]
        public IActionResult GetCategoryById(int categoryId)
        {
            var categoryExists = _categoryRepository.CategoryExists(categoryId);
            if (!categoryExists) return NotFound("Category not found");

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(categoryId));
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("product/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(404)]
        public IActionResult GetProductByCategory(int categoryId)
        {
            var products = _mapper.Map<List<ProductDto>>(_categoryRepository.GetProductByCategory(categoryId));
            if (!ModelState.IsValid) return BadRequest();
            return Ok(products);

        }
    }
}
