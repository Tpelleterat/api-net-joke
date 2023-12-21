using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetJoke.Models
{
    public class OrderNumberRequest
    {
        public string Numbers { get; set; } = default!;

        public int SortDirection { get; set; } = default!;

    }
}
