using Microsoft.EntityFrameworkCore;
using OpenJobs.Models;
using OpenJobs.Data;
using Microsoft.AspNetCore.Identity;
using System.Net;
namespace OpenJobs.Services
{
    public class JobsService : IJobsService
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JobsService(ApplicationDbContext dbcontext, UserManager<IdentityUser> userManager, IHttpContextAccessor HttpContextAccessor)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _httpContextAccessor = HttpContextAccessor;
        }

        public async Task<string> AddNewJob(JobDto request)
        {
            string Message = string.Empty;
            if (request == null)
                Message = "Please make sure all the fields are answered!";

            Job NewJob = new Job()
            {
                JobTitle = request!.JobTitle,
                Company = request.Company,
                JType = request.JType,
                Location = request.Location,
                Salary = request.Salary,
                HealthCovered = request.HealthCovered,
                ContractType = request.ContractType,
                Description = request.Description
            };
            
            await _dbcontext.Jobs!.AddAsync(NewJob);
            await _dbcontext.SaveChangesAsync();
            Message = $"The job was succesfully added!";

            return Message;
        }

        public async Task<string> DeleteJob(int id)
        {
            string ResponseMessage = string.Empty;
            var job = await _dbcontext.Jobs!.FirstOrDefaultAsync(j => j.Id == id);

            if (job != null)
            {
                _dbcontext.Jobs!.Remove(job);
                await _dbcontext.SaveChangesAsync();
                ResponseMessage = "The job has been removed from our pages.";
                return ResponseMessage;
            }
            ResponseMessage = "Failed to remove the specified job. Please refresh and try again.";
            return ResponseMessage;
        }

        public async Task<string> EditJob(int id, JobDto request)
        {
            string ResponseMessage = string.Empty;
            var job = await _dbcontext.Jobs!.FirstOrDefaultAsync(j => j.Id == id);
            if (job != null)
            {
                job.JobTitle = request.JobTitle;
                job.Company = request.Company;
                job.Location = request.Location;
                job.ContractType = request.ContractType;
                job.Salary = request.Salary;
                job.HealthCovered = request.HealthCovered;
                job.Description = request.Description;
                job.Updated = DateTime.UtcNow;
                
                await _dbcontext.SaveChangesAsync();
                ResponseMessage = "Changes performed successfully!";
                return ResponseMessage;                
            }
            ResponseMessage = "We are sorry, the changes requested could not be performed!";
            return ResponseMessage;
        }

        public async Task<List<Job>>? GetMultipleJobs()
        {
            var jobs = await _dbcontext.Jobs!.Where(j => j.Closed == false).ToListAsync();

            if (jobs == null) return null!;

            return !jobs.Any() ? null! : jobs;

            // return jobs;
        }

        public async Task<Job>? GetSingleJob(int id)
        {
            var job = await _dbcontext.Jobs!.FirstOrDefaultAsync(j => j.Id == id);
            
            if (job == null) return null!;
            return job;
        }

        public async Task<string> UnlistJob(int id)
        {
            var ujob = await _dbcontext.Jobs!.FirstOrDefaultAsync(j => j.Id == id);
            if (ujob != null)
            {
                ujob.Closed = true;
                await _dbcontext.SaveChangesAsync();
                return "The job has been unlisted";
            }
            return "Failed to get the job. please refresh and try again.";
        }

        public async Task<string> ApplyForJob(int JobId, JobApplicationDto request)
        {
            string Response = string.Empty;
            JobApplication NewApplication = new JobApplication();

            if (request != null)
            {
                if (!_httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
                {
                    Response = "you are not authorized!";
                    return Response;
                }
                
                var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
                NewApplication.AppliedBy = user.Result;
                NewApplication.JobId = JobId;
                NewApplication.CoverLetter = request.CoverLetter;
                NewApplication.Resume = request.Resume;
                NewApplication.StoredResume = request.StoredResume;
                NewApplication.EducationLevel = request.EducationLevel;

                await _dbcontext.JobApplications!.AddAsync(NewApplication);
                await _dbcontext.SaveChangesAsync();
                Response = "your application was successful";
                return Response;
            }

            Response = "Error processing your application. Please check and try again after a few minutes.";
            return Response;
        }
    }
}