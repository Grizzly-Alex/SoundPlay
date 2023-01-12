using System.ComponentModel.DataAnnotations.Schema;

namespace SoundPlay.DAL.Models
{
    public sealed class Guitar : Product
    {
        public int FrestCount { get; set; }
        public int StringsCount { get; set; }
        public int ShapeId { get; set; }
        [ForeignKey("ShapeId")]
        public GuitarShape Shape { get; set; }
        public int SoundboardId { get; set; }
        [ForeignKey("SoundboardId")]
        public Material Soundboard { get; set; }
        public int NeckId { get; set; }
        [ForeignKey("NeckId")]
        public Material Neck { get; set; }
        public int FretboardId { get; set; }
        [ForeignKey("FretboardId")]
        public Material Fretboard { get; set; }
        public int PickupSetId { get; set; }
        [ForeignKey("PickupSetId")]
        public PickupSet PickupSet { get; set; }
        public int TremoloTypeId { get; set; }
        [ForeignKey("TremoloTypeId")]
        public TremoloType TremoloType { get; set; }
    }
}
