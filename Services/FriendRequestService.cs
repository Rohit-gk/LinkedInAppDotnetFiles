using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Services
{
   public interface IFriendRequestService
    {
        IEnumerable<NonConnectionFriendModel> AllNonFriendConnection( string loginUserId);
        Task<FriendRequestModel> AddFriendRequest(string receiverId,string senderId);
        IEnumerable<RequestViewModel> GetFriendRequests(string id);

        Entities.FriendRequest UpdateInvitionStatus(int RequestId, string status);
    }

    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestDal _friendRequestDal;
        public FriendRequestService(IFriendRequestDal friendRequestDal)
        {
            this._friendRequestDal = friendRequestDal;
        }

        public async Task<FriendRequestModel> AddFriendRequest(string receiverId, string senderId)
        {
            //var Object = new FriendRequest
            //{
            //    SenderId = obj.SenderId,
            //    ReceiverId = obj.ReceiverId,
            //    status = "false"
            //};

            var result = await _friendRequestDal.AddFriendRequest(receiverId, senderId);
            return new FriendRequestModel
            {
                RequestId = result.RequestId,
            };
        }

        public IEnumerable<RequestViewModel> GetFriendRequests(string id)
        {
            var request = _friendRequestDal.GetFriendRequests(id);
            return (from req in request
                    select new RequestViewModel
                    {
                        Name = req.Name,
                        requestId = req.requestId,
                        Photo = req.Photo,
                        Postion = req.Postion

                    }).ToList();
            
        }


        public IEnumerable<NonConnectionFriendModel> AllNonFriendConnection(string loginUserId)
        {
            var user = _friendRequestDal.AllNonFriendConnection(loginUserId);
            return (from users in user
                    select new NonConnectionFriendModel
                    {
                        UserId = users.UserId,
                        Name = users.Name,
                        Postion = users.Postion,
                        Photo = users.Photo,
                    }).ToList();
        }


        public Entities.FriendRequest UpdateInvitionStatus(int RequestId, string status)
        {
            var res = _friendRequestDal.UpdateInvitionStatus(RequestId, status);
            return res;

        }

    }
}
