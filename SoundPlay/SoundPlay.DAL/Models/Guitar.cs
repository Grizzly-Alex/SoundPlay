namespace SoundPlay.DAL.Models;

public sealed class Guitar : Product
{
    public GuitarCategory GuitarCategory { get; set; }
    public byte FretsCount { get; set; }
    public byte StringsCount { get; set; }
    public int? ShapeId { get; set; }
    public int SoundboardId { get; set; }
    public int NeckId { get; set; }
    public int FretboardId { get; set; }
    public int? TremoloTypeId { get; set; } 
    public int? PickupSetId { get; set; }
    [ForeignKey("ShapeId")] public GuitarShape? Shape { get; set; }
    [ForeignKey("SoundboardId")] public Material? Soundboard { get; set; }
    [ForeignKey("NeckId")] public Material? Neck { get; set; }
    [ForeignKey("FretboardId")] public Material? Fretboard { get; set; }
    [ForeignKey("PickupSetId")] public PickupSet? PickupSet { get; set; }
    [ForeignKey("TremoloTypeId")] public TremoloType? TremoloType { get; set; }
}
