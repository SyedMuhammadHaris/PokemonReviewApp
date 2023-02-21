using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    //data attributes
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = pokemonRepository;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            return Ok(pokemons);
        }
    }
}
