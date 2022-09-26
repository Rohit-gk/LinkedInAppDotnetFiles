using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Services
{
    public interface IProfileService
    {
        IEnumerable<ProfileModel> GetProfile();
        ProfileModel GetProfileById(int Id);
        Task<ProfileModel> AddProfile(ProfileModel profileObj);
        ProfileModel UpdateProfile(ProfileModel updateProfile);
        ProfileModel DeleteProfile(int id);
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileDal _ProfileDal;
        public ProfileService(IProfileDal ProfileDal)
        {
            _ProfileDal = ProfileDal;
        }

        public async Task<ProfileModel> AddProfile(ProfileModel profileObj)
        {
            var obj = new Profile
            {
                UserId = profileObj.UserId,
                FirstName = profileObj.FirstName,
                LastName = profileObj.LastName,
                Location = profileObj.Location,
                Mobile = profileObj.Mobile,
                BirthDate = profileObj.BirthDate,
                Email = profileObj.Email,
                Address = profileObj.Address,
                Organization = profileObj.Organization,
                UploadCV = profileObj.UploadCV
            };

            var result = await _ProfileDal.AddProfile(obj);
            return new ProfileModel
            {
                UserId = result.UserId,
            };
        }

        public ProfileModel DeleteProfile(int UserId)
        {
            var deleteProfile = _ProfileDal.DeleteProfile(UserId);
            return new ProfileModel
            {
                UserId = deleteProfile.UserId,
                FirstName = deleteProfile.FirstName,
                LastName = deleteProfile.LastName,
                Location = deleteProfile.Location,
                Mobile = deleteProfile.Mobile,
                BirthDate = deleteProfile.BirthDate,
                Email = deleteProfile.Email,
                Address = deleteProfile.Address,
                Organization = deleteProfile.Organization,
                UploadCV = deleteProfile.UploadCV
            };
        }

        public IEnumerable<ProfileModel> GetProfile()
        {
            var getProfiles = _ProfileDal.GetProfile();
            return (from profile in getProfiles
                    select new ProfileModel
                    {
                        UserId = profile.UserId,
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        Location = profile.Location,
                        Mobile = profile.Mobile,
                        BirthDate = profile.BirthDate,
                        Email = profile.Email,
                        Address = profile.Address,
                        Organization = profile.Organization,
                        UploadCV = profile.UploadCV
                    }).ToList();
        }

        public ProfileModel GetProfileById(int Id)
        {
            var getProfile = _ProfileDal.GetProfileById(Id);
            if (getProfile != null)
            {
                return new ProfileModel
                {
                    UserId = getProfile.UserId,
                    FirstName = getProfile.FirstName,
                    LastName = getProfile.LastName,
                    Location = getProfile.Location,
                    Mobile = getProfile.Mobile,
                    BirthDate = getProfile.BirthDate,
                    Email = getProfile.Email,
                    Address = getProfile.Address,
                    Organization = getProfile.Organization,
                    UploadCV = getProfile.UploadCV
                };
            }
            else
            {
                return null;
            }
        }

        public ProfileModel UpdateProfile(ProfileModel updateProfile)
        {
            var obj = new Profile
            {
                UserId = updateProfile.UserId,
                FirstName = updateProfile.FirstName,
                LastName = updateProfile.LastName,
                Location = updateProfile.Location,
                Mobile = updateProfile.Mobile,
                BirthDate = updateProfile.BirthDate,
                Email = updateProfile.Email,
                Address = updateProfile.Address,
                Organization = updateProfile.Organization,
                UploadCV = updateProfile.UploadCV

            };
            var updateData = _ProfileDal.UpdateProfile(obj);
            return new ProfileModel
            {
                UserId = updateProfile.UserId,
                FirstName = updateProfile.FirstName,
                LastName = updateProfile.LastName,
                Location = updateProfile.Location,
                Mobile = updateProfile.Mobile,
                BirthDate = updateProfile.BirthDate,
                Email = updateProfile.Email,
                Address = updateProfile.Address,
                Organization = updateProfile.Organization,
                UploadCV = updateProfile.UploadCV
            };

        }
    }
 }
