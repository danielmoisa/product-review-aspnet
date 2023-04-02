using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Dtos;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(404)]
        public IActionResult GetCountryById(int countryId)
        {
            var countryExists = _countryRepository.CountryExists(countryId);
            if (!countryExists) return NotFound("Country not found");

            var product = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(countryId));
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(product);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(country);
        }
    }
}
