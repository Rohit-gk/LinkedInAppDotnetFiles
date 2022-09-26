using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.DAL
{
    public interface IProfileDal
    {
        IEnumerable<Profile> GetProfile();
        Profile GetProfileById(int id);
        Task<Profile> AddProfile(Profile profileObj);
        Profile UpdateProfile(Profile updateProfile);
        Profile DeleteProfile(int id);
    }

    public class ProfileDal : IProfileDal
    {
        private readonly ApplicationDbContext _context;
        public ProfileDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Profile> AddProfile(Profile profileObj)
        {
            var data = await _context.UserProfile.AddAsync(profileObj);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public Profile DeleteProfile(int id)
        {
            var result = _context.UserProfile.Where(i => i.UserId == id).FirstOrDefault();
            if (result != null)
            {
                _context.UserProfile.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public Profile GetProfileById(int id)
        {
            return _context.UserProfile.FirstOrDefault(i => i.UserId == id);
        }

        public IEnumerable<Profile> GetProfile()
        {
            return _context.UserProfile.ToList();
        }

        public Profile UpdateProfile(Profile updateProfile)
        {
            var update = _context.UserProfile.FirstOrDefault(a => a.UserId == updateProfile.UserId);
                if (update!=null)
                {
                //data.UserId = updateProfile.UserId;
                update.FirstName = updateProfile.FirstName;
                update.LastName = updateProfile.LastName;
                update.Location = updateProfile.Location;
                update.Mobile = updateProfile.Mobile;
                update.BirthDate = updateProfile.BirthDate;
                update.Email = updateProfile.Email;
                update.Address = updateProfile.Address;
                update.Organization = updateProfile.Organization;
                update.UploadCV = updateProfile.UploadCV;

                    var updatedData = _context.UserProfile.Update(update);
                    _context.SaveChanges();
                    return updatedData.Entity;
                }
            
            return updateProfile;
        }
    }
}
