using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SoundPlay.DAL.Models;
using System.ComponentModel;


namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class GuitarViewModel : ProductViewModel
    {
		[DisplayName("Frets Count")]
		public byte FretsCount { get; set; }

        [DisplayName("Strings Count")] 
        public byte StringsCount { get; set; }

        public int? ShapeId { get; set; }
        public int? SoundboardId { get; set; }
        public int? NeckId { get; set; }
        public int? FretboardId { get; set; }
        public int? TremoloTypeId { get; set; }
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
}
