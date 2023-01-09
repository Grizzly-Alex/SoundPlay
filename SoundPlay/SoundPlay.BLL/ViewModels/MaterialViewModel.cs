using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tremolo Type")]
        public string? Name { get; set; }
    }
}