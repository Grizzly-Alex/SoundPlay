namespace SoundPlay.Infrastructure.Businesslogic.ViewModels;

public sealed class ColorViewModel : EntityViewModel
{
    [DisplayName("Color")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }
}
