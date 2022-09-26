using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Headline { get; set; }
        public string CurrentPostion { get; set; }
        public string Organization { get; set; }
        public string ProfileImage { get; set; }
    }
}
