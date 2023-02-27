using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{

    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext context;
        public ReviewerRepository(DataContext context)
        {
                this.context = context;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault(); ;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        public ICollection<Review> GetReviewersByReviewer(int reviewerId)
        {
            return context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return context.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
