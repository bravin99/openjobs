using System.ComponentModel.DataAnnotations;

namespace OpenJobs.Models
{
    public enum JobType
    {
        Remote,
        Onsite,
        Hybrid
    }

    public class Job
    {
        [Required]
        public int Id { get; set; }
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
        public string ContractType { get; set; } = string.Empty;
        [Required]
        [StringLength(7000, ErrorMessage = "The description is too long")]
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; }
        public bool Closed { get; set; } = false;
        public ICollection<ReportJob>? Reports { get; set; }
    }
}