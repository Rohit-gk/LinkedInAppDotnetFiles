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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly UserManager<ApplicationUserNew> _userManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public JobController(IJobService jobService, UserManager<ApplicationUserNew> userManager, RoleManager<IdentityRole> roleManger)
        {
            _jobService = jobService;
            this.roleManger = roleManger;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Jobs()
        {
            try
            {
                return Ok(_jobService.Jobs());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddJob(JobModel job)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                job.CreatedBy = user.Id; 
                return Ok(await _jobService.AddJob(job));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            try
            {
                return Ok(_jobService.DeleteJob(id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }
    }
}
