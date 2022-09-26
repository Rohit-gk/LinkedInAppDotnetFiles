using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Model
{
    public class JobModel
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string Organization { get; set; }
        public DateTime Date { get; set; }
        public string Postion { get; set; }
        public string OrganizationLogo { get; set; }
        public string CreatedBy { get; set; }
    }
}
