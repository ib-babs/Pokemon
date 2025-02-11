namespace Pokemon.Models
{
    public class PokemonModel
    {
        // access_modifier datatype name
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Power { get; set; }
        public string? ImageUrl { get; set; }
        public string Color { get; set; }
    }
}
