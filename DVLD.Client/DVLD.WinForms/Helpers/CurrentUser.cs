using DVLD.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Helpers
{
    public static class CurrentUser
    {
        public static LoginUserDto? User { get; set; }
    }
}
