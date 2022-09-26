using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Services
{
    public interface IJobApplierService
    {
        Task<JobApplierModel> JobApplier(JobApplierModel job);
    }

    public class JobApplierService : IJobApplierService
    {
        private readonly IJobApplierDal JobApplierDal;
        public JobApplierService(IJobApplierDal JobApplierDal)
        {
            this.JobApplierDal = JobApplierDal;
        }

        public async Task<JobApplierModel> JobApplier(JobApplierModel job)
        {
            var obj = new JobApplier
            {
                JobId = job.JobId,
                Id = job.Id,
                ApplicantId = job.ApplicantId,
                AppliedDate = DateTime.Now,
            };

            var result = await JobApplierDal.JobApplier(obj);
            return new JobApplierModel
            {
                JobId = result.JobId,
            };
        }
    }
}