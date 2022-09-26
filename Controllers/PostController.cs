using LinkedInAppProject.Entities;
using LinkedInAppProject.Model;
using LinkedInAppProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAppProject.Controllers
{
    //[Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet]
        public IActionResult GetPosts()
        {
            try
            {
                return Ok(_postService.GetPosts());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetPostById(int Id)
        {
            try
            {
                return Ok(_postService.GetPostById(Id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPost(PostModel postObj)
        {
            try
            {
                return Ok(await _postService.AddPost(postObj));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdatePost(PostModel updatePost)
        {
            try
            {
                return Ok(_postService.UpdatePost(updatePost));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                return Ok(_postService.DeletePost(id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);
            }
        }

    }
}