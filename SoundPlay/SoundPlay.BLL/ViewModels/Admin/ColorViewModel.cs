using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class ColorViewModel
    {
        public int Id { get; set; }

        [DisplayName("Color")]
        public string Name { get; set; }
    }
}
