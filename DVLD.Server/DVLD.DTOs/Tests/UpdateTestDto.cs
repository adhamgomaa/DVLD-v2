using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.Tests;

public class UpdateTestDto
{
    [Required]
    public int AppointmentID { get; set; }
    [Required]
    public bool Result { get; set; }
    public string? Notes { get; set; }
    [Required]
    public int UserId { get; set; }
}

