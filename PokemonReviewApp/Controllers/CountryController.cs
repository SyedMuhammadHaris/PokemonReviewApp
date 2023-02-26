﻿using AutoMapper;
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
    public class CountryController : Controller
    {
        private readonly ICountryRepository countryRespository;
        private readonly IMapper mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper) 
        {
            this.countryRespository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetCountries()
        {
            var countries = mapper.Map<List<CountryDto>>(countryRespository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!countryRespository.CountryExist(countryId))
                return NotFound();

            //var pokemon = pokemonRepository.GetPokemon(pokeId);
            var country = mapper.Map<CountryDto>(countryRespository.GetCountry(countryId)); ;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerByCountry(int ownerId)
        {
            var countryByOwner = mapper.Map<CountryDto>(
                countryRespository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countryByOwner);
        }

        [HttpGet("/ownersByCountry/{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            //var ownersByCountry = mapper.Map<List<CountryDto>>(countryRespository.GetOwnersFromCountry(countryId));
            var ownersByCountry = countryRespository.GetOwnersFromCountry(countryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ownersByCountry);
        }
    }
}
