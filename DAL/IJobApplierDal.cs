using LinkedInAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.DAL
{
    public interface IJobApplierDal
    {
        Task<JobApplier> JobApplier(JobApplier job);
    }
    public class JobApplierDal : IJobApplierDal
    {
        private readonly ApplicationDbContext _context;

        public JobApplierDal(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<JobApplier> JobApplier(JobApplier job)
        {
            var data = await _context.JobAppliers.AddAsync(job);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
    }
}
