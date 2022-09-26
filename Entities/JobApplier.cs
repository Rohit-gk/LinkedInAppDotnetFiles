using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Entities
{
    public class JobApplier
    {

        [Key]
        public int Id { get; set; }
        public string ApplicantId { get; set; }
        public DateTime AppliedDate { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Job Jobs { get; set; }
    }
}
