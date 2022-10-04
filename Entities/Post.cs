using System.ComponentModel.DataAnnotations;

namespace LinkedInAppProject.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
       
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string Author { get; set; }
    }
}
