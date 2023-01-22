using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [DisplayName("Material")]
        public string Name { get; set; }
    }
}