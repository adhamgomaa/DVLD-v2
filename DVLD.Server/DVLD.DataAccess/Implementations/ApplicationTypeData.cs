using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations
{
    public sealed class ApplicationTypeData(AppDbContext context) : IApplicationTypeData
    {
        public async Task<ApplicationType?> FindTypesAsync(AppTypeEnum id, CancellationToken cancellationToken)
        {
            var type = await context.ApplicationTypes.FindAsync([(int)id], cancellationToken);
            return type;
        }

        public async Task<ApplicationType?> FindTypesAsync(string title, CancellationToken cancellationToken)
        {
            var type = await context.ApplicationTypes.AsNoTracking().SingleOrDefaultAsync(t => t.Title == title, cancellationToken);
            return type;
        }

        public async Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            var types = await context.ApplicationTypes.AsNoTracking().ToListAsync(cancellationToken);
            return types;
        }
        public async Task<bool> UpdateTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken)
        {
            var type = await context.ApplicationTypes.FindAsync([updateTypes.ApplicationTypeId], cancellationToken);
            if(type is null)
                return false;

            type.Title = updateTypes.Title;
            type.Fees = updateTypes.Fees;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
