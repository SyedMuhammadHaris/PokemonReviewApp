namespace PokemonReviewApp.Dto
{
    // In dto we limit the we exposed to api
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
