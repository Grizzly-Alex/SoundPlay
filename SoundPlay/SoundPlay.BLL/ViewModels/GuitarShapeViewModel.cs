using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class GuitarShapeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("GuitarShape")]
        public string? Name { get; set; }
    }
}