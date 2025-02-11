using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    public class PokemonController(PokemonDbContext context) : Controller
    {
        //public IEnumerable<PokemonModel> PokemonModels = [
        //    new(){Name = "Pikachu", Owner = "Tunji", Power = "Lightening", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png", Color = "orange"},
        //    new(){Name = "Balbasaur", Owner = "Yusuf", Power = "Water", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png", Color = "green"},
        //    new(){Name = "Charmander", Owner = "Glory", Power = "Fire", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png", Color = "darkorange"},
        //    new(){Name = "Squirtle", Owner = "Oscar", Power = "Stone", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png", Color = "teal"},
        //    ];

        public IActionResult Pokemons()
        {
            return View(context.Pokemons.ToList());

        }

        [HttpGet]
        public IActionResult AddPokemon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon(PokemonModel pokemon, [FromForm] IFormFile image)
        {
            if (ModelState.IsValid) // If the input is all validated
            {
                if (image != null)
                {
                    Console.WriteLine(image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Guid.NewGuid().ToString()); // Path to save the image uploaded
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream); // Copy the data in the image we uploaded to another filestream
                    }
                    pokemon.ImageUrl = image.FileName;
                }
                context.Pokemons.Add(pokemon);
                await context.SaveChangesAsync();
                return RedirectToAction("Pokemons");
            }

            return View();
        }


    }
}
