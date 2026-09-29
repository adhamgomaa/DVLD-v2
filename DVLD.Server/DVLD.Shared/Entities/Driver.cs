using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Shared.Entities
{
    public class Driver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public Driver()
        {
            DriverID = -1;
            PersonID = -1;
            UserID = -1;
            CreatedDate = DateTime.Now;
        }

        public Driver(int driverID, int personID, int userID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            UserID = userID;
            CreatedDate = createdDate;
        }

    }
}
