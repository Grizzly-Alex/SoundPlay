namespace SoundPlay.Web.ViewModels;

public sealed class EditUserViewModel
{
    public string? Id { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "This field must not be empty!")]
    public string Name { get; set; }

    [Display(Name = "Street Address")]
    public string? StreetAddress { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "State")]
    public string? State { get; set; }

    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }
    public IEnumerable<SelectListItem>? RoleList { get; set; }
}
