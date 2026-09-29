using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class ApplicationType
    {
        public AppTypeEnum TypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public ApplicationType(AppTypeEnum typeID, string title, decimal fees)
        {
            TypeID = typeID;
            Title = title;
            Fees = fees;
        }
    }
}
