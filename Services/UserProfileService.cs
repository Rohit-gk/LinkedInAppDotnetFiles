using LinkedInAppProject.Authentication;
using LinkedInAppProject.DAL;

using UserProfileModel = LinkedInAppProject.Model.UserProfileModel;

namespace LinkedInAppProject.Services
{
    public interface IUserProfileService
    {
        UserProfileModel GetUserProfile(string userId);
        UserProfileModel UpdateUserProfile(UserProfileModel userProfileModel);
    }

    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfile _userProfileDal;
        public UserProfileService(IUserProfile userProfileDal)
        {
            _userProfileDal = userProfileDal;
        }

        public UserProfileModel GetUserProfile(string userId)
        { 
            var getSingleProfile = _userProfileDal.GetUserProfile(userId);
            return getSingleProfile;
        }

        public UserProfileModel UpdateUserProfile(UserProfileModel userProfileModel)
        {
            var obj = new ApplicationUserNew
            {
                Id = userProfileModel.Id,
                Email=userProfileModel.Email,
                Name=userProfileModel.Name,
                Organization=userProfileModel.Organization,
                CurrentPostion=userProfileModel.CurrentPostion,
                BirthDate=userProfileModel.BirthDate,
                ProfileImage=userProfileModel.ProfileImage,
                Address=userProfileModel.Address,
                Headline=userProfileModel.Headline,

            };
            var updateData = _userProfileDal.UpdateUserProfile(obj);
            return new UserProfileModel
            {
                Id=updateData.Id,
            };
        }
    }
}

