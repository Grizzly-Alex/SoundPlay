using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DTO.ViewModels
{
	public sealed class GuitarShapeViewModel
	{
		public int Id { get; set; }
		
		[Required]
		[DisplayName("GuitarShape")]
		public string? Name { get; set; }
	}
}
