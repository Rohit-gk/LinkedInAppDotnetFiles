using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Entities
{
    public class FriendRequest
    {

        [Key]
        public int RequestId { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string status { get; set; }
    }
}
