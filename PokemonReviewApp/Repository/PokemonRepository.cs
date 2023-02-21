using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext context) 
        {
            this.context = context;
           
        }
        public ICollection<Pokemon> GetPokemons() 
        {
            return context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
