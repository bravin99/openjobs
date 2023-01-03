using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenJobs.Models
{
    public record ReportJobDto
    {
        [Required(ErrorMessage = "we need some details in order to take action.")]
        [StringLength(700, ErrorMessage = "Your message is too long")]
        public string ReporterMessage { get; set; } = string.Empty;
    }
}