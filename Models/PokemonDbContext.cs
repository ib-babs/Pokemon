using Microsoft.EntityFrameworkCore;

namespace Pokemon.Models
{
    public class PokemonDbContext(DbContextOptions<PokemonDbContext> opts): DbContext(opts)
    {
        public DbSet<PokemonModel> Pokemons { get; set; }
    }
}
