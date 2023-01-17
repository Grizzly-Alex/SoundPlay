using SoundPlay.DAL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels
{
    public sealed class GuitarViewModel : ProductViewModel
    {
        [Required]
		[DisplayName("Frets Count")]
		public int FretsCount { get; set; }

        [Required]
        [DisplayName("Strings Count")] 
        public int StringsCount { get; set; }

        public int? ShapeId { get; set; }
        public int? SoundboardId { get; set; }
        public int? NeckId { get; set; }
        public int? FretboardId { get; set; }
        public int? TremoloTypeId { get; set; }
        public int? PickupSetId { get; set; }
        public GuitarShape? Shape { get; set; }

        [DisplayName ("Soundboard Material")] 
        public Material? Soundboard { get; set; }

		[DisplayName("Neck Material")] 
        public Material? Neck { get; set; }

		[DisplayName("Fretboard Material")]
        public Material? Fretboard { get; set; }

		[DisplayName("Pickup Set")]
        public PickupSet? PickupSet { get; set; }

		[DisplayName("Tremolo Type")]
        public TremoloType? TremoloType { get; set; }
    }
}
