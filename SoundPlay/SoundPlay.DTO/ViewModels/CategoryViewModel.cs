using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DTO.ViewModels
{
	public sealed class CategoryViewModel
	{
		public int Id { get; set; }
		
		[Required]
		[DisplayName("Category")]
		public string? Name { get; set; }
	}
}
