using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Applications
{
    public class GetAppDto
    {
        public int AppID { get; set; }
        public int PersonId { get; set; }
        public DateTime AppDate { get; set; }
        public AppTypeEnum Type { get; set; }
        public AppStatusEnum AppStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public decimal Fees { get; set; }
        public int UserId { get; set; }
        public GetAppDto()
        {
            AppID = -1;
            PersonId = -1;
            AppDate = DateTime.Now;
            Type = AppTypeEnum.NewLocalDrivingLicense;
            AppStatus = AppStatusEnum.New;
            StatusDate = DateTime.Now;
            Fees = 0;
            UserId = -1;
        }
    }
}
