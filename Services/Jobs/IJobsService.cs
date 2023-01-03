using OpenJobs.Models;

namespace OpenJobs.Services
{
    public interface IJobsService
    {
        public Task<string> AddNewJob(JobDto request);
        public Task<string> EditJob(int id, JobDto request);
        public Task<string> DeleteJob(int id);
        public Task<string> UnlistJob(int id);
        public Task<Job>? GetSingleJob(int id);
        public Task<List<Job>>? GetMultipleJobs();
        public Task<string> ApplyForJob(int JobId, JobApplicationDto request);
    }

}