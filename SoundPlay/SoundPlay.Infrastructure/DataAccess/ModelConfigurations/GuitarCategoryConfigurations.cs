using SoundPlay.Core.Models.Entities.Items;

namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class GuitarCategoryConfiguration : IEntityTypeConfiguration<GuitarCategory>
{
    public void Configure(EntityTypeBuilder<GuitarCategory> builder)
    {
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
