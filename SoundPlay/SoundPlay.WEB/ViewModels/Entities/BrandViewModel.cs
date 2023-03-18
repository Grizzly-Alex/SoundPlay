namespace SoundPlay.Web.ViewModels.Entities;

public sealed class BrandViewModel : EntityViewModel
{
    [DisplayName("Brand")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }
}