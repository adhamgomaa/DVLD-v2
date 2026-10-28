using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class ApplicationTypeService(IApplicationTypeData applicationTypeData) : IApplicationTypeService
    {
        public async Task<bool> UpdateAppTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken)
        {
            return await applicationTypeData.UpdateTypesAsync(updateTypes, cancellationToken);
        }

        public async Task<ApplicationType?> FindTypeAsync(AppTypeEnum typeID, CancellationToken cancellationToken)
        {
            ApplicationType? type = await applicationTypeData.FindTypesAsync(typeID, cancellationToken);
            if (type != null)
                return type;
            return null;
        }

        public async Task<ApplicationType?> FindTypeAsync(string title, CancellationToken cancellationToken)
        {
            ApplicationType? type = await applicationTypeData.FindTypesAsync(title, cancellationToken);
            if (type != null)
                return type;
            return null;
        }

        public async Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            return await applicationTypeData.GetAllTypesAsync(cancellationToken);
        }
    }
}
