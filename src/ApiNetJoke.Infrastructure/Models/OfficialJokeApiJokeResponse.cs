namespace ApiNetJoke.Infrastructure.Models
{
    public class OfficialJokeApiJokeResponse
    {
        public required int Id { get; set; }

        public required string Type { get; set; }

        public required string Setup { get; set; }

        public required string Punchline { get; set; }

        public override string ToString()
        {
            return $"{Setup} {Punchline}";
        }

    }
}
