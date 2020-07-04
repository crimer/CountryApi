using System;

namespace CountryApi.Models
{
    // Gross Domestic Product - Валовой внутренний продукт
    // HDI - Индекс человеческого развития

    public enum CarTraffic
    {
        left,
        right,
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string OfficialLanguage { get; set; }
        public string Capital { get; set; }
        public int Territory { get; set; }
        public virtual Population Population { get; set; }
        public virtual GDP GDP { get; set; }
        public double HDI { get; set; }
        public string Currency { get; set; }
        public CarTraffic CarTraffic { get; set; }
    }
}
