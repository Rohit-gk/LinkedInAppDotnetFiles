using System;
using System.ComponentModel.DataAnnotations;

namespace LinkedInAppProject.Entities
{
    public class Profile
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Organization { get; set; }
        public string UploadCV { get; set; }
    }
}
