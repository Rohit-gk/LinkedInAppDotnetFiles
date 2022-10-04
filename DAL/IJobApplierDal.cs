using LinkedInAppProject.Entities;

namespace LinkedInAppProject.DAL
{
    public interface IJobApplierDal
    {
       JobApplier JobAppliers(JobApplier jobApplier);
    }
    public class JobApplierDal : IJobApplierDal
    {
        private readonly ApplicationDbContextNew _context;

        public JobApplierDal(ApplicationDbContextNew context)
        {
            this._context = context;
        }
        public JobApplier JobAppliers(JobApplier jobApplier)
        {
            var data =  _context.JobAppliers.Add(jobApplier);
           _context.SaveChanges();
            return data.Entity;
        }
    }
}
