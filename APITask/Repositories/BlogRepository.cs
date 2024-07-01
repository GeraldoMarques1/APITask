using APITask.Data;
using APITask.Dtos;
using APITask.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Reflection;

namespace APITask.Repositories
{
	public class BlogRepository
	{
		private readonly OnlineShopDbContext _context;

		public BlogRepository(OnlineShopDbContext context) { 
			_context = context;
		}
		
		public async Task<List<BlogPostResponse>> GetBlogList()
		{
			return _context.BlogPosts.Select(blog => new BlogPostResponse()
			{
				Id = blog.Id,
				Title = blog.Title,
				Content = blog.Content,
				Comments = _context.Comments.Where(c => c.BlogId == blog.Id).ToList(),
			}).ToList();
		}

        public async Task<List<BlogPostResponse>> GetBlogListById(int id)
        {

            return _context.BlogPosts.Where(b => b.Id == id).Select(blog => new BlogPostResponse()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Comments = _context.Comments.Where(c => c.BlogId == blog.Id).ToList(),
            }).ToList();
        }

        public async Task<bool> AddBlogPost(BlogPostRequest model)
		{
			BlogPost newBlog = new BlogPost()
			{
				Title = model.Title,
				Content = model.Content,
			};
			_context.BlogPosts.Add(newBlog);
			_context.SaveChanges();

			return true;
		}

        public async Task<bool> AddComment(int id, CommentRequest model)
        {
            Comment newComment = new Comment()
            {
                BlogId = id,
                Content = model.Content,
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();

            return true;
        }
    }
}
