namespace SoundPlay.Core.Models;

public class GuitarCategory : Item
{
    public List<Guitar> Guitars { get; set; }

    private GuitarCategory(GuitarTag enumGuitar)
	{
		Id = (int)enumGuitar;
		Name = enumGuitar.GetDisplayName();
	}
	protected GuitarCategory() { }

    public static implicit operator GuitarCategory(GuitarTag enumGuitar) => new GuitarCategory(enumGuitar);
    public static implicit operator GuitarTag(GuitarCategory classGuitar) => (GuitarTag)classGuitar.Id;
}
