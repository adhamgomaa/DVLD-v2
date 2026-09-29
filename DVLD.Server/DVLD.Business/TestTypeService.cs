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
    public class TestTypeService
    {
        public static async Task<bool> UpdateAppTypesAsync(TestType updateType)
        {
            return await TestTypeData.UpdateTypesAsync(updateType);
        }

        public static async Task<TestType?> FindTypeAsync(TestTypeEnum typeID)
        {
            TestType? type = await TestTypeData.FindTypesAsync(typeID);
            if (type != null)
                return type;
            return null;
        }

        public static async Task<List<TestType>> GetAllTypesAsync()
        {
            return await TestTypeData.GetAllTypesAsync();
        }
    }
}
