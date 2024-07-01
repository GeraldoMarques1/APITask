using System.ComponentModel.DataAnnotations;

namespace APITask.Models
{
	public class BlogPost
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

	}
}
