using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class GuitarShapeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Guitar shape")]
        public string? Name { get; set; }
    }
}