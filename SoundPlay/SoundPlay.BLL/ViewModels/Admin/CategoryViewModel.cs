using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Category")]
        public string Name { get; set; }
    }
}