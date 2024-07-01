using APITask.Models;

namespace APITask.Dtos
{
	public class BlogPostResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
