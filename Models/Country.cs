using System;
using System.ComponentModel;

namespace CountryApi.Models
{
    // Gross Domestic Product - Валовой внутренний продукт
    // HDI - Индекс человеческого развития

    public enum CarTraffic : byte
    {
        [Description("Левосторонее")]
        Left = 1,
        [Description("Правосторонее")]
        Right = 2,
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string OfficialLanguage { get; set; }
        public string Capital { get; set; }
        public int Territory { get; set; }
        public long Population { get; set; }
        public double GdpTotal { get; set; }
        public double HDI { get; set; }
        public string Currency { get; set; }
        public CarTraffic CarTraffic { get; set; }
    }
}
