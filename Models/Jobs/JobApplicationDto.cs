using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace OpenJobs.Models
{
    public class JobApplicationDto
    {
        [Required]
        public EducationLevel EducationLevel { get; set; }
        [Required]
        public string? Resume { get; set; }
        [Required]
        public string CoverLetter { get; set; } = string.Empty;
    }
}