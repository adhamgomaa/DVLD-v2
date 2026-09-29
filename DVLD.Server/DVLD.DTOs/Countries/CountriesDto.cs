using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Countries
{
    public class CountriesDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public CountriesDto()
        {
            CountryId = -1;
            CountryName = string.Empty;
        }
    }
}
