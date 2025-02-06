using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    public class PokemonController : Controller
    {
        public IEnumerable<PokemonModel> PokemonModels = [
            new(){Name = "Pikachu", Owner = "Tunji", Power = "Lightening", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png", Color = "orange"},
            new(){Name = "Balbasaur", Owner = "Yusuf", Power = "Water", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png", Color = "green"},
            new(){Name = "Charmander", Owner = "Glory", Power = "Fire", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png", Color = "darkorange"},
            new(){Name = "Squirtle", Owner = "Oscar", Power = "Stone", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png", Color = "teal"},
            ];


        public IActionResult Pokemons()
        {
            return View(PokemonModels);
        }


    }
}
