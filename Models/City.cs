using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryApi.Models
{
    public enum Status
    {
        Catital
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual  Country Country { get; set; }
        public Status Status { get; set; }
        public double Square { get; set; }

        public long Population { get; set; }
    }
}
