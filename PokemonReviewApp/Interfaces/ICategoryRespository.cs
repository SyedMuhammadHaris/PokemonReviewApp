using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRespository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCatogory(int categoryid);

        bool CategoryExists(int categoryid);

        //POST methods starts
        bool CreateCategory (Category category);
        bool Save();
    }
}
