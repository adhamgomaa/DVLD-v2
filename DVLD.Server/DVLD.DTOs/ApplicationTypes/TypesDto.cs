using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.ApplicationTypes
{
    public class TypesDto
    {
        public AppTypeEnum TypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public TypesDto()
        {
            TypeID = AppTypeEnum.NewLocalDrivingLicense;
            Title = string.Empty;
            Fees = 0;
        }
    }
}
