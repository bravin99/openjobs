using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenJobs.Models;

namespace OpenJobs.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}

    public DbSet<Job>? Jobs { get; set; }
    public DbSet<ReportJob>? JobReports { get; set; }
    public DbSet<JobApplication>? JobApplications { get; set; }
}