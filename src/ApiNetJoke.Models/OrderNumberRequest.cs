using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Models
{
    public class OrderNumberRequest
    {
        [Required]
        [RegularExpression("^\\d+(,\\d+)*$")]
        public required string Numbers { get; set; }

        [Required]
        [Range(0, 1)]
        public int? SortDirection { get; set; } = default!;
    }
}
