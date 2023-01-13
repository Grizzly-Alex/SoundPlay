using System.ComponentModel.DataAnnotations;

namespace SoundPlay.DAL.Models
{
    public sealed class Material
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
    }
}