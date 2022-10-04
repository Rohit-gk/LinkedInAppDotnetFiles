using LinkedInAppProject.Authentication;
using LinkedInAppProject.Model;
using LinkedInAppProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LinkedInAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplierController : ControllerBase
    {
        private readonly IJobApplierService _jobApplierService;
        private readonly UserManager<ApplicationUserNew> _userManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public JobApplierController(IJobApplierService jobApplierService, UserManager<ApplicationUserNew> userManager, RoleManager<IdentityRole> roleManger)
        {
            _jobApplierService = jobApplierService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> JobApplier(JobApplierModel job)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                job.ApplicantId = user.Id;
                return Ok( _jobApplierService.JobAppliers(job));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }
    }
}
