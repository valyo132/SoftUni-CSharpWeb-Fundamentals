using System.ComponentModel.DataAnnotations;

using static ForumApp.Common.DataConstrants.Post;

namespace ForumApp.ViewModels
{
    public class AddPostViewModel
    {
        [Required]
        [MaxLength(TitleMaxLength), MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(TextMaxLength), MinLength(TextMinLength)]
        public string Text { get; set; } = null!;
    }
}
