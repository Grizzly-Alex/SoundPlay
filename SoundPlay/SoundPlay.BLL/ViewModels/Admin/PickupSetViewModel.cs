using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class PickupSetViewModel
    {
        public int Id { get; set; }

        [DisplayName("Pickup set")]
		[Required(ErrorMessage = "This field must not be empty!")]
		public string Name { get; set; }
    }
}
