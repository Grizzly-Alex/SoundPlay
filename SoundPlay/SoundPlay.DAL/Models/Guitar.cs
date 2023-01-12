namespace SoundPlay.DAL.Models
{
    public sealed class Guitar : Product
    {
        public int FrestCount { get; set; }
        public int StringsCount { get; set; }
        public int ShapeId { get; set; }
        public GuitarShape Shape { get; set; }
        public int SoundboardId { get; set; }
        public Material Soundboard { get; set; }
        public int NeckId { get; set; }
        public Material Neck { get; set; }
        public int FretboardId { get; set; }
        public Material Fretboard { get; set; }
        public int PickupSetId { get; set; }
        public PickupSet PickupSet { get; set; }
        public int TremoloTypeId { get; set; }
        public TremoloType TremoloType { get; set; }
    }
}
