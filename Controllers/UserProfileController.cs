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
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUserNew> _userManager;
        private readonly RoleManager<IdentityRole> roleManger;
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(UserManager<ApplicationUserNew> userManager, RoleManager<IdentityRole> roleManger, IUserProfileService userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return Ok(_userProfileService.GetUserProfile(user.Id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile(UserProfileModel userProfileModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                userProfileModel.Id = user.Id;
                return Ok(_userProfileService.UpdateUserProfile(userProfileModel));
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error" + ex.Message);
            }
        }

    }
}
