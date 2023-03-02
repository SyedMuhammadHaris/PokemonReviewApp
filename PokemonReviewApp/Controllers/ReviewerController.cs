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
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IMapper mapper;
        public ReviewerController(IReviewerRepository reviewerRepository , IMapper mapper)
        {
            this.reviewerRepository = reviewerRepository;
            this.mapper = mapper;   
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewers()
        {
            //var reviewers = mapper.Map<List<ReviewerDto>>(reviewerRepository.GetReviewers());
            var reviewers = reviewerRepository.GetReviewers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviewer = mapper.Map<ReviewerDto>(reviewerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }
            var reviewsByReviewer = mapper.Map<List<ReviewDto>>(
                reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewsByReviewer);
        }
    }
}
