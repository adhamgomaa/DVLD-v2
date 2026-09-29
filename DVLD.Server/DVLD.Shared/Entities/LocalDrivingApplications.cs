using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class LocalDrivingApplications
    {
        public int AppId { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime AppDate { get; set; }
        public int PassedTest { get; set; }
        public string Status { get; set; }

        public LocalDrivingApplications(int appId, string className, string nationalNo, string fullName, DateTime appDate, int passedTest, string status)
        {
            AppId = appId;
            ClassName = className;
            NationalNo = nationalNo;
            FullName = fullName;
            AppDate = appDate;
            PassedTest = passedTest;
            Status = status;
        }
    }
}
