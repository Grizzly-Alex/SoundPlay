namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class MaterialViewModel : EntityViewModel
{
    [DisplayName("Material")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}