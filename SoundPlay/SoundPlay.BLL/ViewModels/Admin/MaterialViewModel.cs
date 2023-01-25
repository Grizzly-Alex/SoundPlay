using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [DisplayName("Material")]
		[Required(ErrorMessage = "This field must not be empty!")]
		public string Name { get; set; }
    }
}