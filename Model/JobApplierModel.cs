using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Model
{
    public class JobApplierModel
    {
        public int Id { get; set; }
        public string ApplicantId { get; set; }
        public string Date { get; set; }
        public int JobId { get; set; }

    }
}
