namespace SoundPlay.DAL.Models;

public sealed class Material : Item
{
    public List<Guitar>? GuitarsOfSoundboard { get; set; }
    public List<Guitar>? GuitarsOfNeck { get; set; }
    public List<Guitar>? GuitarsOfFretboard { get; set; }
}