namespace SoundPlay.Web.ViewModels;

public sealed class TremoloTypeViewModel : EntityViewModel
{
    [DisplayName("Tremolo type")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }
}