using APITask.Data;
using APITask.Dtos;
using APITask.Helper;
using APITask.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APITask.Controllers
{
	[Route("api")]
	[ApiController]
	public class APIController: ControllerBase
	{
		private readonly BlogRepository _blogRepository;

		public APIController(OnlineShopDbContext context)
		{
            _blogRepository = new BlogRepository(context);
		}

		[HttpPost("posts")]
		public async Task<IActionResult> AddBlogPost(BlogPostRequest blogRequest)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var result = await _blogRepository.AddBlogPost(blogRequest);
					return Ok("Add BlogPost Success!");
				}
				else
				{
					return BadRequest("Check if all fields are filled");
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("posts")]
		public async Task<IActionResult> GetBlogPostList()
		{
			try
			{
				var result = await _blogRepository.GetBlogList();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpGet("posts/{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            try
            {
                var result = await _blogRepository.GetBlogListById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("posts/{id}/comments")]
        public async Task<IActionResult> AddComment(int id, CommentRequest commentRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _blogRepository.AddComment(id, commentRequest);
                    return Ok("Add Comment Success!");
                }
                else
                {
                    return BadRequest("Check if all fields are filled");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
