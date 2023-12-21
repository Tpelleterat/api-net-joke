using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Api.Configuration
{
    internal class OfficialJokeApiSettings
    {
        [Required]
        [Url]
        public required string Url { get; set; }
    }
}
