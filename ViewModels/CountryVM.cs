using System;
using System.ComponentModel.DataAnnotations;

namespace CountryApi.ViewModels
{
    public class CountryVM
    {
        [Required]
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        [Required]
        public string OfficialLanguage { get; set; }
        [Required]
        public string Capital { get; set; }
        public int Territory { get; set; }
        public double HDI { get; set; }
        public string Currency { get; set; }
    }
}
