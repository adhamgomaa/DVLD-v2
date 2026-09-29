using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public Country(int CountryId, string CountryName)
        {
            this.CountryId = CountryId;
            this.CountryName = CountryName;
        }
    }
}
