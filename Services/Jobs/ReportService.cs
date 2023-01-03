using Microsoft.EntityFrameworkCore;
using OpenJobs.Data;
using OpenJobs.Models;

namespace OpenJobs.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportJob>> GetReportsByJobId(int jobId)
        {
            var reports = await _context.JobReports!.Where(r =>  r.JobId == jobId).ToListAsync();

            return reports.Any() ? reports : null!;
        }

        public async Task<string> SubmitReport(int jobId, ReportJobDto request)
        {
            string ResponseMessage = string.Empty;
            ReportJob NewReport = new ReportJob();
            if (request != null)
            {
                NewReport.ReporterMessage = request.ReporterMessage;
                NewReport.JobId = jobId;
                NewReport.ReportDate = DateTime.UtcNow;

                await _context.JobReports!.AddAsync(NewReport);
                await _context.SaveChangesAsync();
                ResponseMessage = "The report was submitted sucessfully!";
                return ResponseMessage;
            }
            ResponseMessage = "There was an error while trying to make the report please try again later!";
            return ResponseMessage;
        }
    }
}