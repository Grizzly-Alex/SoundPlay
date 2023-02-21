namespace SoundPlay.Infrastructure.Businesslogic.ViewModels;

public sealed class GuitarCategoryViewModel : EntityViewModel
{
    [DisplayName("Category")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }
}
