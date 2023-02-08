namespace SoundPlay.DAL.Models;

public class GuitarCategory : Entity
{	
	private GuitarCategory(GuitarType enumGuitar)
	{
		Id = (int)enumGuitar;
		Name = enumGuitar.GetDisplayName();
	}
	protected GuitarCategory() { }

    public static implicit operator GuitarCategory(GuitarType enumGuitar) => new GuitarCategory(enumGuitar);
    public static implicit operator GuitarType(GuitarCategory classGuitar) => (GuitarType)classGuitar.Id;
}
