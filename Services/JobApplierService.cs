using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;


namespace LinkedInAppProject.Services
{
    public interface IJobApplierService
    {
       JobApplierModel JobAppliers(JobApplierModel job);
    }

    public class JobApplierService : IJobApplierService
    {
        private readonly IJobApplierDal JobApplierDal;
        public JobApplierService(IJobApplierDal JobApplierDal)
        {
            this.JobApplierDal = JobApplierDal;
        }

        public JobApplierModel JobAppliers(JobApplierModel job)
        {
            var obj = new JobApplier
            {
                JobId = job.JobId,
                ApplicantId = job.ApplicantId,
                AppliedDate = DateTime.Now,
            };

            var result =  JobApplierDal.JobAppliers(obj);
            return new JobApplierModel
            {
                JobId = result.JobId,
            };
        }
    }
}