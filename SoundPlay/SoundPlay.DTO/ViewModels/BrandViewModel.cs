using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DTO.ViewModels
{
	public sealed class BrandViewModel
	{
		public int Id { get; set; }
		
		[Required]
		[DisplayName("Brand")]
		public string? Name { get; set; }
	}
}
