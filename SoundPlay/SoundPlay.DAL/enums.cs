namespace SoundPlay.DAL;

public enum GuitarType 
{ 
	[Display(Name = "Electric Guitar")] ElectricGuitar = 0,
	[Display(Name = "Accoustic Guitar")] AcousticGuitar = 1,
	[Display(Name = "Classic Guitar")] ClassicGuitar = 2,
	[Display(Name = "Electric Bass")] ElectricBass = 3,
	[Display(Name = "Accoustic Bass")] AcousticBass = 4,
	[Display(Name = "Ukulele")] Ukulele = 5,
}