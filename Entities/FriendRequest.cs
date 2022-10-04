using System.ComponentModel.DataAnnotations;

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
