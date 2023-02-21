namespace SoundPlay.Infrastructure.Businesslogic.ViewModels;

public sealed class GuitarShapeViewModel : EntityViewModel
{
    [DisplayName("Guitar shape")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }
}