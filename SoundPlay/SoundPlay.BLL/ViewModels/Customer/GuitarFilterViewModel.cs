namespace SoundPlay.BLL.ViewModels.Customer;

public sealed class GuitarFilterViewModel : ProductFilterViewModel
{
	public int? CategoryId { get; set; }
	public int? BrandId { get; set; }
	public int? ColorId { get; set; }
	public int? GuitarShapeId { get; set; }
	public int? SoundboardId { get; set; }
	public int? NeckId { get; set; }
	public int? FretboardId { get; set; }
	public int? PickupSetId { get; set; }
	public int? TremoloTypeId { get; set; }
	public IEnumerable<SelectListItem>? Brands { get; set; }
	public IEnumerable<SelectListItem>? Colors { get; set; }
	public IEnumerable<SelectListItem>? GuitarShapes { get; set; }
	public IEnumerable<SelectListItem>? Soundboards { get; set; }
	public IEnumerable<SelectListItem>? Necks { get; set; }
	public IEnumerable<SelectListItem>? Fretboards { get; set; }
	public IEnumerable<SelectListItem>? PickupSets { get; set; }
	public IEnumerable<SelectListItem>? TremoloTypes { get; set; }
}