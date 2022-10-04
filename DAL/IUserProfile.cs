using LinkedInAppProject.Authentication;
using LinkedInAppProject.Model;
using System.Linq;


namespace LinkedInAppProject.DAL
{
public interface IUserProfile
    {
        UserProfileModel GetUserProfile(string userId);
        ApplicationUserNew UpdateUserProfile(ApplicationUserNew ApplicationUserNew);
    }

    public class UserProfile : IUserProfile
    {
        private readonly ApplicationDbContextNew _context;
        public UserProfile(ApplicationDbContextNew context)
        {
            _context = context;
        }

      public UserProfileModel GetUserProfile(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            UserProfileModel userProfile = new UserProfileModel()
            {
                Id=user.Id,
                Name=user.Name,
                Email=user.Email,
                Organization = user.Organization,
                CurrentPostion=user.CurrentPostion,
                ProfileImage=user.ProfileImage,
                Address=user.Address,
                BirthDate=user.BirthDate
            };              
            return userProfile;
        }

        public ApplicationUserNew UpdateUserProfile(ApplicationUserNew ApplicationUserNew)
        {
            var update = _context.Users.FirstOrDefault(a => a.Id == ApplicationUserNew.Id);
            if (update != null)
            {
                update.Name = ApplicationUserNew.Name;
                update.Address = ApplicationUserNew.Address;
                update.Email = ApplicationUserNew.Email;
                update.Headline = ApplicationUserNew.Headline;
                update.Organization = ApplicationUserNew.Organization;
                // update.PhoneNumber = ApplicationUserNew.PhoneNumber;
                update.ProfileImage = ApplicationUserNew.ProfileImage;
                update.CurrentPostion = ApplicationUserNew.CurrentPostion;
                update.BirthDate = ApplicationUserNew.BirthDate;

                var updatedData = _context.Users.Update(update);
                _context.SaveChanges();
                return updatedData.Entity;
            }
            return ApplicationUserNew;
        }
    }
}
