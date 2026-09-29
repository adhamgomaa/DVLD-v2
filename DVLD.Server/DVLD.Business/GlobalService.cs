using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public static class GlobalService
    {
        public static User? CurrentUser { get; set; }
    }
}
