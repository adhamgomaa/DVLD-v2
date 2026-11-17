using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Models
{
    public class LicenseHistory
    {
        public int LicenseID { get; set; }
        public int AppID { get; set; }
        public required string ClassName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
