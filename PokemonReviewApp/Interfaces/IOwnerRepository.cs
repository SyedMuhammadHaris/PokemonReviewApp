using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        public Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnerOfAPokemomn(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);

    }
}
