using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class BrandViewModel
    {
        public int Id { get; set; }

        [DisplayName("Brand")]
        [Required(ErrorMessage = "This field must not be empty!")]
        public string Name { get; set; }
    }
}