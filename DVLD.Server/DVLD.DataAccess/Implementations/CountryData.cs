using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class CountryData(AppDbContext context) : ICountryData
    {
        public async Task<Country?> FindCountryAsync(int countryId, CancellationToken cancellationToken)
        {
            var country = await context.Countries.FindAsync([countryId], cancellationToken);
            return country;
        }
        public async Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken)
        {
            var country = await context.Countries
                                .AsNoTracking()
                                .SingleOrDefaultAsync(c => c.CountryName == countryName, cancellationToken);
            return country;
        }

        public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
        {
            var countries = await context.Countries.AsNoTracking().ToListAsync(cancellationToken);
            return countries;
        }
    }
}
