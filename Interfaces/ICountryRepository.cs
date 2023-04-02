using ProductReview.Models;

namespace ProductReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        bool CountryExists(int countryId);
    }
}
