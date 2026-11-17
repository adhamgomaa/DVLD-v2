using DVLD.Shared.Enums;

namespace DVLD.DTOs.Applications;
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
    }
