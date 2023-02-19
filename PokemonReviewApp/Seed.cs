using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", email = "Smith@gmail.com" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", email = "Jones@gmail.com" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", email = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", email = "Smith@gmail.com" } },
                                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", email = "Jones@gmail.com" } },
                                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){Name = "Jessica", email = "McGregor@gmail.com"} },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            Gym = "Mistys Gym",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){Name = "Teddy", email = "Smith@gmail.com"} },
                                new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){Name = "Taylor", email = "Jones@gmail.com"} },
                                new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){Name = "Jessica", email = "McGregor@gmail.com"} },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash",
                            Gym = "Ashs Gym",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}