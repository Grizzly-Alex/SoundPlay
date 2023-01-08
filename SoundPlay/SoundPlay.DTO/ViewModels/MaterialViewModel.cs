using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DTO.ViewModels
{
	public sealed class TremoloTypeViewModel
	{
		public int Id { get; set; }
		
		[Required]
		[DisplayName("Tremolo Type")]
		public string? Name { get; set; }
	}
}
