using System.ComponentModel.DataAnnotations;

namespace APITask.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int BlogId { get; set; }
    }
}
