using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class LocalLicense : Application
    {
        public int LocalId { get; set; }
        public int AppId { get; set; }
        public int ClassId { get; set; }

        public LocalLicense()
        {
            LocalId = -1;
            ClassId = -1;
            AppId = -1;
        }

        public LocalLicense(int localId, int appId, int classId)
        {
            LocalId = localId;
            ClassId = classId;
            AppId = appId;
        }
    }
}
