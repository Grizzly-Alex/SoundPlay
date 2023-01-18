using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
