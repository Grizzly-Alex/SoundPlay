using SoundPlay.Core.Models.Entities.Items;

namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

		builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
