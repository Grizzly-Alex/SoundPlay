namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class ColorViewModel
{
    public int Id { get; set; }

    [DisplayName("Color")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}
