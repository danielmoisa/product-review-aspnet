using AutoMapper;
using ProductReview.Data;
using ProductReview.Interfaces;
using ProductReview.Models;

namespace ProductReview.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CountryExists(int countryId)
        {
            return _context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();   
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(c => c.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
