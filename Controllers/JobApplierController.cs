using LinkedInAppProject.Authentication;
using LinkedInAppProject.Model;
using LinkedInAppProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplierController : ControllerBase
    {
        private readonly IJobApplierService _jobApplierService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public JobApplierController(JobApplierService jobApplierService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManger)
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
                return Ok(await _jobApplierService.JobApplier(job));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }
    }
}
