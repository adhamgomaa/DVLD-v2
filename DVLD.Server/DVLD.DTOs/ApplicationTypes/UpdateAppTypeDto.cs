using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.ApplicationTypes
{
    public class UpdateAppTypeDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Fees { get; set; }

        public UpdateAppTypeDto()
        {
            Title = string.Empty;
            Fees = 0;
        }
    }
}
