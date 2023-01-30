namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class CategoryViewModel
{
    public int Id { get; set; }

    [DisplayName("Category")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}