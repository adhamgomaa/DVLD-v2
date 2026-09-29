using DVLD.Shared.Enums;

namespace DVLD.Shared.Entities
{
    public class Application
    {
        public int AppID { get; set; }
        public int PersonId { get; set; }
        public DateTime AppDate { get; set; }
        public AppTypeEnum Type { get; set; }
        public AppStatusEnum AppStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public decimal Fees { get; set; }
        public int UserId { get; set; }
        public Application()
        {
            AppID = -1;
            PersonId = -1;
            AppDate = DateTime.Now;
            AppStatus = AppStatusEnum.New;
            Type = AppTypeEnum.NewLocalDrivingLicense;
            StatusDate = DateTime.Now;
            Fees = 0;
            UserId = -1;
        }

        public Application(int appID, int personId, DateTime date, AppTypeEnum types, AppStatusEnum status, DateTime statusDate, decimal fees, int userId)
        {
            AppID = appID;
            PersonId = personId;
            AppDate = date;
            Type = types;
            AppStatus = status;
            StatusDate = statusDate;
            Fees = fees;
            UserId = userId;
        }
    }
}
