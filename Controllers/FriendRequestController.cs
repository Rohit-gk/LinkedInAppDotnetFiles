using LinkedInAppProject.Authentication;
using LinkedInAppProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LinkedInAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _friendRequestService;
        private readonly UserManager<ApplicationUserNew> _userManager;
        private readonly RoleManager<IdentityRole> roleManger;
       

        public FriendRequestController(IFriendRequestService friendRequestService, UserManager<ApplicationUserNew> userManager, RoleManager<IdentityRole> roleManger)
        {
            _friendRequestService = friendRequestService;
            this.roleManger = roleManger;
            this._userManager = userManager;
        }



        [HttpGet]
        [Route("[action]")]
        public async Task <IActionResult> AllNonFriendConnection()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return Ok(_friendRequestService.AllNonFriendConnection(user.Id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }
   
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFriendRequest()
            {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return Ok(_friendRequestService.GetFriendRequests(user.Id));
        }


        [HttpGet("{receiverId}")]
        public async Task<IActionResult> AddFriendRequest(string receiverId)
        {
         
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return Ok(await _friendRequestService.AddFriendRequest(receiverId, user.Id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateInvitionStatus(int RequestId,string status)
        {
            try
            {
                return Ok(_friendRequestService.UpdateInvitionStatus(RequestId, status));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
