using SoundPlay.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class GuitarViewModel : ProductViewModel
    {
        [Required] public int FrestCount { get; set; }
        [Required] public int StringsCount { get; set; }
        public int? ShapeId { get; set; }
        public int? SoundboardId { get; set; }
        public int? NeckId { get; set; }
        public int? FretboardId { get; set; }
        public int? TremoloTypeId { get; set; }
        public int? PickupSetId { get; set; }
        public GuitarShape? Shape { get; set; }
        public Material? Soundboard { get; set; }
        public Material? Neck { get; set; }
        public Material? Fretboard { get; set; }
        public PickupSet? PickupSet { get; set; }
        public TremoloType? TremoloType { get; set; }
    }
}
