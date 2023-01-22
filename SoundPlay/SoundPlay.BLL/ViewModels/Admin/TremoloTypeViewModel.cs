using System.ComponentModel;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public sealed class TremoloTypeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Tremolo type")]
        public string Name { get; set; }
    }
}