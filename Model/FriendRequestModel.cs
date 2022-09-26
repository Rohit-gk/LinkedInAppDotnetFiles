using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Model
{
    public class FriendRequestModel
    {
        public int RequestId { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string status { get; set; }
    }
}
