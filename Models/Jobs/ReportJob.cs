using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenJobs.Models
{
    public class ReportJob
    {
        public int Id { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        [Required(ErrorMessage = "we need some details in order to take action.")]
        [StringLength(1000, ErrorMessage = "Your message is too long")]
        public string ReporterMessage { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    }

}