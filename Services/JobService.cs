using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Services
{
    public interface IJobService
    {
        IEnumerable<Job> Jobs();
        Task<JobModel> AddJob(JobModel job);
        JobModel DeleteJob(int id);
    }

    public class JobService : IJobService
    {
        private readonly IJobDal JobDal;
        public JobService(IJobDal JobDal)
        {
            this.JobDal = JobDal;
        }

        public async Task<JobModel> AddJob(JobModel job)
        {
            var obj = new Job
            {
                JobId = job.JobId,
                JobName = job.JobName,
                Organization = job.Organization,
                Date = DateTime.Now,
                Postion = job.Postion,
                OrganizationLogo = job.OrganizationLogo,
                CreatedBy = job.CreatedBy


            };

            var result = await JobDal.AddJob(obj);
            return new JobModel
            {
                JobId = result.JobId,
                //Title = result.Title,
                //Content = result.Content,
                //Summary = result.Summary,
                //ImageUrl = result.ImageUrl,
                //UrlHandle = result.UrlHandle,
                //Author = result.Author
            };
        }

        public JobModel DeleteJob(int id)
        {
            var deleteJob = JobDal.DeleteJob(id);
            return new JobModel
            {
                JobId = deleteJob.JobId,
                JobName = deleteJob.JobName,
                Organization = deleteJob.Organization,
                Postion = deleteJob.Postion,
                OrganizationLogo = deleteJob.OrganizationLogo,
                Date = deleteJob.Date,
                CreatedBy = deleteJob.CreatedBy
            };
        }

        public IEnumerable<Job> Jobs()
        {
            {
                var posts = JobDal.Jobs();
                return (from post in posts
                        select new Job
                        {
                            JobId = post.JobId,
                            JobName = post.JobName,
                            Organization = post.Organization,
                            Date = post.Date,
                            Postion = post.Postion,
                            OrganizationLogo = post.OrganizationLogo,
                            CreatedBy = post.CreatedBy
                        }).ToList();
            }
        }
    }
}
