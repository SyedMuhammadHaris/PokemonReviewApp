namespace PokemonReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }


        public ICollection<Review> Reviews { get; set; }
    }
}
