using LinkedInAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.DAL
{
    public interface IJobDal
    {
        IEnumerable<Job> Jobs();
        Task<Job> AddJob(Job job);
        Job DeleteJob(int id);

    }

    public class JobDal : IJobDal
    {
        private readonly ApplicationDbContext _context;

        public JobDal(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Job> AddJob(Job job)
        {
            var data = await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public Job DeleteJob(int id)
        {
            var result = _context.Jobs.Where(i => i.JobId == id).FirstOrDefault();
            if (result != null)
            {
                _context.Jobs.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Job> Jobs()
        {
            return _context.Jobs.ToList();
        }
    }
}
