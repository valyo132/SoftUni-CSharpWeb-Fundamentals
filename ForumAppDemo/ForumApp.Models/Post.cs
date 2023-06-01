using System.ComponentModel.DataAnnotations;

using static ForumApp.Common.DataConstrants.Post;

namespace ForumApp.Models
{
    public class Post
    {
        public Post()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;
    }
}
