using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DTO.ViewModels
{
	public sealed class MaterialViewModel
	{
		public int Id { get; set; }
		
		[Required]
		[DisplayName("Material")]
		public string? Name { get; set; }
	}
}
