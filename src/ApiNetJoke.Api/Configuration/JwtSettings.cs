using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Api.Configuration
{
    public class JwtSettings
    {
        [Required]
        [Url]
        public required string Issuer { get; set; }

        [Required]
        [Url]
        public required string Audience { get; set; }

        [Required]
        public required string Key { get; set; }
    }
}
