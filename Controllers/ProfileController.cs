using LinkedInAppProject.Model;
using LinkedInAppProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Controllers
{
    //[Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [HttpGet]
        public IActionResult Profile()
        {
            try
            {
                return Ok(_profileService.GetProfile());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            } 
        }


        [HttpGet("{Id}")]
        public IActionResult GetProfileById(int Id)
        {
            try
            {
                return Ok(_profileService.GetProfileById(Id));
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProfile(ProfileModel profileObj)
        {
            try
            {
                return Ok(await _profileService.AddProfile(profileObj));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }

        
        [HttpPut]
        public IActionResult UpdateProfile(ProfileModel updateProfile)
        {
            try
            {
                return Ok(_profileService.UpdateProfile(updateProfile));
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            try
            {
                return Ok(_profileService.DeleteProfile(id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }
    }
}
