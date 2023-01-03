using System.ComponentModel.DataAnnotations;

namespace OpenJobs.Models
{
    public class JobDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Please use a shortter title")]
        public string JobTitle { get; set; } = string.Empty;
        [Required]
        public string Company { get; set; } = string.Empty;
        [Required]
        public JobType JType { get; set; } = JobType.Onsite;
        [Required]
        public string Location { get; set; } = string.Empty;
        public double? Salary { get; set; }
        public bool HealthCovered { get; set; } = false;
        [Required]
        public string ContractType { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please describe the position and its tasks")]
        [StringLength(7000, ErrorMessage = "The description is too long")]
        public string Description { get; set; } = string.Empty;
        public bool Closed { get; set; } = false;
    }
}