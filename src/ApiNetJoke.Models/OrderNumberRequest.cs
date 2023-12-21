using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Models
{
    public class OrderNumberRequest
    {
        [Required]
        [RegularExpression("^\\d+(,\\d+)*$")]
        public string? Numbers { get; set; } = default!;

        [Required]
        [Range(0, 1)]
        public int? SortDirection { get; set; } = default!;
    }
}
