using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.DAL
{
    public interface IFriendRequestDal
    {
        IEnumerable<NonConnectionFriendModel> AllNonFriendConnection(string loginUserId);
        Task<FriendRequest> AddFriendRequest(string receiverId, string senderId);
        IEnumerable<RequestViewModel> GetFriendRequests(string id);

        Entities.FriendRequest UpdateInvitionStatus(int RequestId, string status);
    }

    public class FriendRequestDal : IFriendRequestDal
    {
        private readonly ApplicationDbContext _context;

        public FriendRequestDal(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<FriendRequest> AddFriendRequest(string receiverId, string senderId)
        {

            FriendRequest friendRequest = _context.FriendRequests.FirstOrDefault(x => x.SenderId == senderId && x.status.ToLower() == "true");
            if (friendRequest == null)
            {
                friendRequest = new FriendRequest();
                friendRequest.ReceiverId = receiverId;
                friendRequest.SenderId = senderId;
                friendRequest.status = "false";
                var data = await _context.FriendRequests.AddAsync(friendRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                friendRequest.status = "false";
                await _context.SaveChangesAsync();
            }
            return friendRequest;
        }

        public IEnumerable<RequestViewModel> GetFriendRequests(string id)
        {
            var methodSelect = _context.FriendRequests.Where(s => s.ReceiverId == id)
                .Select(s => new RequestViewModel
                {
                    Name = this._context.Users.FirstOrDefault(x => x.Id == s.SenderId).Name,
                    requestId = s.RequestId,
                    Photo = "",
                    Postion = this._context.Users.FirstOrDefault(x => x.Id == id).CurrentPostion
                }); ;


            return methodSelect;
        }


        public IEnumerable<NonConnectionFriendModel> AllNonFriendConnection(string loginUserId)
        {
            var allUsers = from user in _context.Users
                           join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                           join role in _context.Roles on userRoles.RoleId equals role.Id
                             where role.Name != "Admin" &&user.Id!= loginUserId
                           select  new NonConnectionFriendModel
                            {
                                 UserId=user.Id,
                                 Name=user.Name,
                                 Postion=user.CurrentPostion,
                                 Photo=user.ProfileImage,
                            };

            return allUsers;
        }



        public Entities.FriendRequest UpdateInvitionStatus(int RequestId, string status)
        {

            var friendRequest = _context.FriendRequests.FirstOrDefault(s => s.RequestId == RequestId);
            friendRequest.status = status;
            _context.FriendRequests.Update(friendRequest);
            _context.SaveChanges();
            
            return friendRequest;
        }



    }
}
