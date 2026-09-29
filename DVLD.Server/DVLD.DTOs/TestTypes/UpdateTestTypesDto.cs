using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.TestTypes
{
    public class UpdateTestTypesDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Fees { get; set; }

        public UpdateTestTypesDto()
        {
            Title = string.Empty;
            Description = string.Empty;
            Fees = 0;
        }
    }
}
