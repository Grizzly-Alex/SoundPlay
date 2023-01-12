using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class TremoloTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tremolo type")]
        public string? Name { get; set; }
    }
}