using System.ComponentModel.DataAnnotations.Schema;

namespace SoundPlay.DTO.Models
{
    public sealed class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}