using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Helpers
{
    public static class ApiClient
    {
        public static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri(AppConfiguration.BaseApiUrl)
        };
    }
}
