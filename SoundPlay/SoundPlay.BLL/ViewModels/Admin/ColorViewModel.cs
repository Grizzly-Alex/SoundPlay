using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class ColorViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Color")]
        public string? Name { get; set; }
    }
}
