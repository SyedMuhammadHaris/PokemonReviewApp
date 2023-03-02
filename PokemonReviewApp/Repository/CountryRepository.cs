using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;
        public CountryRepository(DataContext context)
        {
            this.context = context;
        }
        public bool CountryExist(int countryId)
        {
            return context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
           return context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int id)
        {

           return context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
        //POST methods
        public bool CreateCountry(Country country)
        {
            context.Add(country);
            return Save();
        }
        public bool Save()
        {
           var saved = context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
