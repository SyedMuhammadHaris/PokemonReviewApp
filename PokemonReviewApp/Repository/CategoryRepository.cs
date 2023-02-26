using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRespository
    {
        private readonly DataContext context;
        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public bool CategoryExists(int categoryid)
        {
           return context.Categories.Any(c => c.Id== categoryid);
        }

        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Id).ToList();
            //return context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCatogory(int categoryid)
        {
            return context.PokemonCategories.Where(c => c.CategoryId == categoryid).Select(c => c.Pokemon).ToList();    
        }
    }
}
