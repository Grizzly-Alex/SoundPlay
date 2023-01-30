namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class PickupSetViewModel : EntityViewModel
{
    [DisplayName("Pickup set")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}
