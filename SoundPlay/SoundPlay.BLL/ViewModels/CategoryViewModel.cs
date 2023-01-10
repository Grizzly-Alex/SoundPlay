using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category")]
        public string? Name { get; set; }
    }
}