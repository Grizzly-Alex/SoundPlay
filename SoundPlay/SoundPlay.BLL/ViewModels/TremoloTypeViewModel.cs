using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public class TremoloTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tremolo type")]
        public string? Name { get; set; }
    }
}