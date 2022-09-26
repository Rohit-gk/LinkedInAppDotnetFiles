using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

       // public string UrlHandle { get; set; }

        public string Author { get; set; }

        //public DateTime PostCreatedDate { get; set; }
    }
}
