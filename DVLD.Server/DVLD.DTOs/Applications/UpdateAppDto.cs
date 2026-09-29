using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Applications
{
    public class UpdateAppDto
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public AppTypeEnum Type { get; set; }
        [Required]
        public AppStatusEnum AppStatus { get; set; }
        [Required]
        public DateTime StatusDate { get; set; }
        [Required]
        public decimal Fees { get; set; }
        [Required]
        public int UserId { get; set; }
        public UpdateAppDto()
        {
            PersonId = -1;
            Type = AppTypeEnum.NewLocalDrivingLicense;
            AppStatus = AppStatusEnum.New;
            StatusDate = DateTime.Now;
            Fees = 0;
            UserId = -1;
        }
    }
}
