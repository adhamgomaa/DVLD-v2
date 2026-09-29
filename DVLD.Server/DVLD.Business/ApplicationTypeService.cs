using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class ApplicationTypeService
    {
        public static async Task<bool> UpdateAppTypesAsync(ApplicationType updateTypes)
        {
            return await ApplicationTypeData.UpdateTypesAsync(updateTypes);
        }

        public static async Task<ApplicationType?> FindTypeAsync(AppTypeEnum typeID)
        {
            ApplicationType? type = await ApplicationTypeData.FindTypesAsync(typeID);
            if (type != null)
                return type;
            return null;
        }

        public static async Task<ApplicationType?> FindTypeAsync(string title)
        {
            ApplicationType? type = await ApplicationTypeData.FindTypesAsync(title);
            if (type != null)
                return type;
            return null;
        }

        public static async Task<List<ApplicationType>> GetAllTypesAsync()
        {
            return await ApplicationTypeData.GetAllTypesAsync();
        }
    }
}
