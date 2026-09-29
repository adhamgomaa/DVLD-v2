using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Drivers
{
    public class GetDriverDto
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public GetDriverDto()
        {
            DriverID = -1;
            PersonID = -1;
            UserID = -1;
            CreatedDate = DateTime.Now;
        }
    }
}
