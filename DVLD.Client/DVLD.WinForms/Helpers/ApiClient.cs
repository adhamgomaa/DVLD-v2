using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Helpers
{
    public static class ApiClient
    {
        public static readonly HttpClient httpClient;
        public static readonly HttpClient AuthClient;

        static ApiClient()
        {
            httpClient = new HttpClient(new BearerTokenHandler
            {
                InnerHandler = new HttpClientHandler()
            })
            {
                BaseAddress = new Uri(AppConfiguration.BaseApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };

            AuthClient = new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri(AppConfiguration.BaseApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
    }
}
