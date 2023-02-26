using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    //Data Attributes
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRespository categoryRespository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRespository categoryRepository, IMapper mapper)
        {
            this.categoryRespository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCatogories() 
        {
            var catogories = mapper.Map<List<CategoryDto>>(categoryRespository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(catogories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200,Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!categoryRespository.CategoryExists(categoryId))
                return NotFound();

            //var pokemon = pokemonRepository.GetPokemon(pokeId);
            var category = mapper.Map<CategoryDto>(categoryRespository.GetCategory(categoryId)); ;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {
            var pokemonsByCategory = mapper.Map<List<PokemonDto>>(
                categoryRespository.GetPokemonByCatogory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemonsByCategory);

        }
    }
}
