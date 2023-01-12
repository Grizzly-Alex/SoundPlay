using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
    internal sealed class ColorModelConfiguration:IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors")
                .HasKey(p => p.Id)
                .HasName("ColorId");

            builder.Property(p => p.Id)
                .HasColumnName("ColorId");

            builder.Property(p => p.Name)
                .HasColumnName("ColorName")
                .IsRequired();
        }
    }
}
