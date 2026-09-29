using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Helpers
{
    public static class ApiRoutes
    {
        public static class Application
        {
            public const string GetId = "Applications/{0}";
            public const string Update = "Applications/{0}";
            public const string Delete = "Applications/{0}";
            public const string Add = "Applications";
        }

        public static class ApplicationType
        {
            public const string GetAll = "ApplicationTypes";
            public const string GetId = "ApplicationTypes/{0}";
            public const string GetTitle = "ApplicationTypes/by-title/{0}";
            public const string Update = "ApplicationTypes/{0}";
        }

        public static class Country
        {
            public const string GetAll = "Countries";
            public const string GetId = "Countries/{0}";
            public const string GetCountryName = "Countries/by-name/{0}";
        }

        public static class DetainLicense
        {
            public const string GetAll = "DetainLicense";
            public const string GetId = "DetainLicense/{0}";
            public const string IsLicenseDetained = "DetainLicense/is-license-detained/{0}";
            public const string ReleaseLicense = "DetainLicense/release-detained-license/{0}";
            public const string Update = "DetainLicense/{0}";
            public const string Add = "DetainLicense";
        }
        public static class Driver
        {
            public const string GetAll = "Drivers";
            public const string GetId = "Drivers/{0}";
            public const string GetPersonId = "Drivers/by-person-id/{0}";
            public const string IsPersonDriver = "Drivers/is-person-driver/{0}";
            public const string Add = "Drivers";
        }

        public static class InternationalLicense
        {
            public const string GetAll = "InternationalLicense";
            public const string GetHistory = "InternationalLicense/by-driver-id/{0}";
            public const string GetId = "InternationalLicense/{0}";
            public const string GetLocalId = "InternationalLicense/by-local-id/{0}";
            public const string GetActiveLicense = "InternationalLicense/active-license-id-by-driver-id/{0}";
            public const string Add = "InternationalLicense";
        }

        public static class LicenseClass
        {
            public const string GetAll = "LicenseClass";
            public const string GetId = "LicenseClass/{0}";
            public const string GetClassName = "LicenseClass/by-classname/{0}";
        } 
        public static class License
        {
            public const string GetAll = "Licenses/by-driver-id/{0}";
            public const string GetId = "Licenses/{0}";
            public const string GetLocalId = "Licenses/license-id-by-local-id/{0}";
            public const string GetNationalNumber = "Licenses/license-id-by-national-number/{0}";
            public const string Deactivate = "Licenses/deactivate/{0}";
            public const string GetActiveLicense = "Licenses/active-license/by-person-id/{0}/by-class-id/{1}";
            public const string Update = "Licenses/{0}";
            public const string Add = "Licenses";
        }
        public static class LocalLicense
        {
            public const string GetAll = "LocalLicense";
            public const string GetId = "LocalLicense/{0}";
            public const string Cancel = "LocalLicense/cancel/{0}";
            public const string CheckSameClass = "LocalLicense/check-same-class/by-person-id/{0}/by-class-id/{1}";
            public const string GetPassedTestCount = "LocalLicense/passed-test-count/{0}";
            public const string GetTotalTrailsTest = "LocalLicense/total-trails-per-test/{0}/{1}";
            public const string IsAnActiveTest = "LocalLicense/is-there-an-active-test/{0}/{1}";
            public const string DosePassTest = "LocalLicense/dose-pass-test-type/{0}/{1}";
            public const string DoseAttendTest = "LocalLicense/dose-attend-test-type/{0}/{1}";
            public const string Update = "LocalLicense/{0}";
            public const string Delete = "LocalLicense/local-id/{0}/app-id/{1}";
            public const string Add = "LocalLicense";
        }
        
        public static class Person
        {
            public const string GetAll = "People";
            public const string GetId = "People/{0}";
            public const string GetNationalNumber = "People/by-national-no/{0}";
            public const string IsExistByNational = "People/{0}/by-national-no/exists";
            public const string IsExist = "People/{0}/exists";
            public const string Update = "People/{0}";
            public const string Delete = "People/{0}";
            public const string Add = "People";
        }

        public static class TestAppointment
        {
            public const string GetAll = "TestAppointments/all/by-local-id/{0}/by-test-type/{1}";
            public const string GetId = "TestAppointments/{0}";
            public const string GetLastAppointment = "TestAppointments/last/by-local-id/{0}/by-test-type/{1}";
            public const string GetTrails = "TestAppointments/trails/by-local-id/{0}/by-test-type/{1}";
            public const string GetTestId = "TestAppointments/test-id/by-appointment-id/{0}";
            public const string IsLock = "TestAppointments/is-lock/by-local-id/{0}/by-test-type/{1}";
            public const string Update = "TestAppointments/{0}";
            public const string Add = "TestAppointments";
        }
        
        public static class Test
        {
            public const string GetId = "Tests/{0}";
            public const string GetLastTest = "Tests/last/local-id/{0}/test-type/{1}";
            public const string Update = "Tests/{0}";
            public const string Add = "Tests";
        }
        
        public static class TestType
        {
            public const string GetAll = "TestTypes";
            public const string GetId = "TestTypes/{0}";
            public const string Update = "TestTypes/{0}";
        }

        public static class User
        {
            public const string GetAll = "Users";
            public const string GetId = "Users/{0}";
            public const string GetInfo = "Users/info/{0}";
            public const string GetUsername = "Users/by-username/{0}";
            public const string Login = "Users/login";
            public const string IsExist = "Users/{0}/exists";
            public const string IsExistByUsername = "Users/{0}/by-username/exists";
            public const string IsExistByPersonId = "Users/{0}/by-person-id/exists";
            public const string Update = "Users/{0}";
            public const string Delete = "Users/{0}";
            public const string Add = "Users";
        }
    }
}
