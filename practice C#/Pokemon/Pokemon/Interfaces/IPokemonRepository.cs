using Pokemon.Dto;
using Pokemon.Models;

namespace Pokemon.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Models.Pokemon> GetPokemons();
        Models.Pokemon GetPokemon(int id);
        Models.Pokemon GetPokemon(string name);
        Models.Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon);
        bool DeletePokemon(Models.Pokemon pokemon);
        bool Save();
    }
}
