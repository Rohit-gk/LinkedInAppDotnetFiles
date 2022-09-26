using LinkedInAppProject.DAL;
using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Services
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetPosts();
        PostModel GetPostById(int Id);
        Task<PostModel> AddPost(PostModel postObj);
        PostModel UpdatePost(PostModel updatePost);
        PostModel DeletePost(int id);
    }
    public class PostService : IPostService
    {
        private readonly IPostDal PostDal;
        public PostService(IPostDal PostDal)
        {
            this.PostDal = PostDal;
        }

        public async Task<PostModel> AddPost(PostModel postObj)
        {
            var obj = new Post
            {
                Id = postObj.Id,
                Title = postObj.Title,
                Content = postObj.Content,
                Summary = postObj.Summary,
                ImageUrl = postObj.ImageUrl,
                Author = postObj.Author

            };

            var result = await PostDal.AddPost(obj);
            return new PostModel
            {
                Id = result.Id,
                //Title = result.Title,
                //Content = result.Content,
                //Summary = result.Summary,
                //ImageUrl = result.ImageUrl,
                //UrlHandle = result.UrlHandle,
                //Author = result.Author
            };
        }

        public PostModel DeletePost(int id)
        {
            var deleteStudent = PostDal.DeletePost(id);
            return new PostModel
            {
                Id = deleteStudent.Id,
                Title = deleteStudent.Title,
                Content = deleteStudent.Content,
                Summary = deleteStudent.Summary,
                ImageUrl = deleteStudent.ImageUrl,
                Author = deleteStudent.Author
            };
        }

        public PostModel GetPostById(int Id)
        {
            var post = PostDal.GetPostById(Id);
            if (post != null)
            {
                return new PostModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Summary = post.Summary,
                    ImageUrl = post.ImageUrl,
                    Author = post.Author
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PostModel> GetPosts()
        {
            var posts = PostDal.GetPosts();
            return (from post in posts
                    select new PostModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        Summary = post.Summary,
                        ImageUrl = post.ImageUrl,
                        Author = post.Author
                    }).ToList();
        }

        public PostModel UpdatePost(PostModel updatePost)
        {
            var obj = new Post
            {
                Id = updatePost.Id,
                Title = updatePost.Title,
                Content = updatePost.Content,
                Summary = updatePost.Summary,
                ImageUrl = updatePost.ImageUrl,
                Author = updatePost.Author

            };
            var updateData = PostDal.UpdatePost(obj);
            return new PostModel
            {
                Id = updatePost.Id,
                Title = updatePost.Title,
                Content = updatePost.Content,
                Summary = updatePost.Summary,
                ImageUrl = updatePost.ImageUrl,
                Author = updatePost.Author
            };

        }
    }
}
