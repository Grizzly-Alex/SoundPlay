using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class PickupSetViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Pickup set")]
        public string? Name { get; set; }
    }
}
