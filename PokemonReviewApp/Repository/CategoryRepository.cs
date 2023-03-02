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

        //POST METHODS
        public bool CreateCategory(Category category)
        {
            //change tracker // the Add method track state of our entity
            //for eg: add.update . modifying
            context.Add(category);
            return Save();
        }
        public bool Save()
        {
            //this .SaveChanges method actually save the data in sql database or its just like insert query
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
