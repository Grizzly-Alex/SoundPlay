using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class PickupConfigurationViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Pickup configuration")]
        public string? Name { get; set; }
    }
}
