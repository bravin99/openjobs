using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Forms;

namespace OpenJobs.Models
{
    public enum EducationLevel
    {
        PhD,
        Masters,
        Degree,
        Diploma,
        Apprentice,
        Highschool
    }
    public class JobApplication
    {
        public int Id { get; set; }
        public IdentityUser? AppliedBy { get; set; }
        public int JobId { get; set; }
        [Required]
        public string Resume { get; set; } = string.Empty;
        public string StoredResume { get; set; } = string.Empty;
        [Required]
        public string CoverLetter { get; set; } = string.Empty;
        public EducationLevel EducationLevel { get; set; } = EducationLevel.Diploma;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
    }
}