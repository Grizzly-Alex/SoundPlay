namespace SoundPlay.DAL.Models;

public class GuitarCategory : Item
{
    public List<Guitar> Guitars { get; set; }

    private GuitarCategory(GuitarType enumGuitar)
	{
		Id = (int)enumGuitar;
		Name = enumGuitar.GetDisplayName();
	}
	protected GuitarCategory() { }

    public static implicit operator GuitarCategory(GuitarType enumGuitar) => new GuitarCategory(enumGuitar);
    public static implicit operator GuitarType(GuitarCategory classGuitar) => (GuitarType)classGuitar.Id;
}
