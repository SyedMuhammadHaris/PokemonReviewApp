using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromCountry(int countryId);

        bool CountryExist(int countryId);

        //POST METHODS
        bool CreateCountry (Country country);
        bool Save();
    }
}
