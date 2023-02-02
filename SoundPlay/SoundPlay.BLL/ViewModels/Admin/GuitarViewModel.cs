namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class GuitarViewModel : ProductViewModel
{
	[DisplayName("Category")]
	public GuitarType GuitarType { get; set; }	

	[DisplayName("Frets Count")]
	[Required(ErrorMessage = "Value {0} must not be empty!")]
	[Range(1, 50, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
	public byte FretsCount { get; set; }

    [DisplayName("Strings Count")]
	[Required(ErrorMessage = "Value {0} must not be empty!")]
	[Range(1, 50, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
	public byte StringsCount { get; set; }

	[DisplayName("Shape")]
	public int? ShapeId { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Soundboard")]
	public int SoundboardId { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Neck")]
	public int NeckId { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Fretboard")]
	public int FretboardId { get; set; }

	[DisplayName("Tremolo Type")]
	public int? TremoloTypeId { get; set; }

	[DisplayName("Pickup Set")]
	public int? PickupSetId { get; set; }

	[DisplayName("Shape")]
	[ValidateNever]
	public GuitarShape? Shape { get; set; }

    [DisplayName ("Soundboard Material")]
	[ValidateNever]
	public Material? Soundboard { get; set; }

	[DisplayName("Neck Material")]
	[ValidateNever]
	public Material? Neck { get; set; }

	[DisplayName("Fretboard Material")]
	[ValidateNever]
	public Material? Fretboard { get; set; }

	[DisplayName("Pickup Set")]
	[ValidateNever]
	public PickupSet? PickupSet { get; set; }

	[DisplayName("Tremolo Type")]
	[ValidateNever]
	public TremoloType? TremoloType { get; set; }
}
