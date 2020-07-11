using CountryApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CountryApi.ViewModels
{
    public class CityVM
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public virtual Country Country { get; set; }
        public Status Status { get; set; }
        [Required]
        public double Square { get; set; }
        [Required]
        public long Population { get; set; }
    }
}
