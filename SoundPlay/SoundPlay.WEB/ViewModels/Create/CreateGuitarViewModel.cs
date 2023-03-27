namespace SoundPlay.Web.ViewModels.Create;

public sealed class CreateGuitarViewModel
{
    public GuitarViewModel? GuitarViewModel { get; set; }
    public IEnumerable<SelectListItem>? Categories { get; set; }
    public IEnumerable<SelectListItem>? Brands { get; set; }
    public IEnumerable<SelectListItem>? Colors { get; set; }
    public IEnumerable<SelectListItem>? GuitarShapes { get; set; }
    public IEnumerable<SelectListItem>? Soundboards { get; set; }
    public IEnumerable<SelectListItem>? Necks { get; set; }
    public IEnumerable<SelectListItem>? Fretboards { get; set; }
    public IEnumerable<SelectListItem>? PickupSets { get; set; }
    public IEnumerable<SelectListItem>? TremoloTypes { get; set; }

    public CreateGuitarViewModel()
    {
    }

    public CreateGuitarViewModel(
        GuitarViewModel? guitarViewModel,
        IEnumerable<SelectListItem>? categories,
        IEnumerable<SelectListItem>? brands,
        IEnumerable<SelectListItem>? colors,
        IEnumerable<SelectListItem>? guitarShapes,
        IEnumerable<SelectListItem>? materials,
        IEnumerable<SelectListItem>? pickupSets,
        IEnumerable<SelectListItem>? tremoloTypes)
    {
        GuitarViewModel = guitarViewModel;
        Categories = categories;
        Brands = brands;
        Colors = colors;
        GuitarShapes = guitarShapes;
        Soundboards = materials;
        Necks = materials;
        Fretboards = materials;
        PickupSets = pickupSets;
        TremoloTypes = tremoloTypes;
    }
}
