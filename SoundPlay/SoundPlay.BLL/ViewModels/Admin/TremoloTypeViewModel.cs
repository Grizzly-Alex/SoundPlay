namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class TremoloTypeViewModel : EntityViewModel
{

    [DisplayName("Tremolo type")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}