using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenJobs.Models;

namespace OpenJobs.Services
{
    public interface IReportService
    {
        public Task<string> SubmitReport(int jobId, ReportJobDto request);
        public Task<List<ReportJob>> GetReportsByJobId(int JobId);
    }
}