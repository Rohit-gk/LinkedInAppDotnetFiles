using LinkedInAppProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.DAL
{
    public interface IPostDal
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int id);
        Task<Post> AddPost(Post postObj);
        Post UpdatePost(Post updatePost);
        Post DeletePost(int id);
    }

    public class PostDal : IPostDal
    {
        private readonly ApplicationDbContext _context;

        public PostDal(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Post> AddPost(Post postObj)
        {
            var data = await _context.Posts.AddAsync(postObj);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public Post DeletePost(int id)
        {
            var result = _context.Posts.Where(i => i.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.Posts.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public Post UpdatePost(Post updatePost)
        {
            var update = _context.Posts.FirstOrDefault(a => a.Id == updatePost.Id);

            if (update != null)
            {
                update.Title = updatePost.Title;
                update.Content = updatePost.Content;
                update.Summary = updatePost.Summary;
                update.ImageUrl = updatePost.ImageUrl;
                //data.UrlHandle = updatePost.UrlHandle;
                update.Author = updatePost.Author;

                var updatedData = _context.Posts.Update(update);
                _context.SaveChanges();
                return updatedData.Entity;
            }
            return updatePost;
        }
    }
}