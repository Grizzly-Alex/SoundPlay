using Microsoft.EntityFrameworkCore;

namespace SoundPlay.DAL.Data.ModelConfigurations;

internal sealed class GuitarModelConfiguration : IEntityTypeConfiguration<Guitar>
{
    public void Configure(EntityTypeBuilder<Guitar> builder)
    {
        builder.ToTable("Guitars")
            .HasKey(p => p.Id)
            .HasName("GuitarId");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.GuitarCategory)
            .IsRequired()
			.HasColumnName("Category")
			.HasConversion(p => p.ToString(), p => Enum.Parse<GuitarCategory>(p));

        builder.Property(p => p.FretsCount)
            .HasColumnName("FreastCount")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.StringsCount)
            .HasColumnName("StringsCount")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("Discription")
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(p => p.PictureUrl)
            .HasColumnName("PictureUrl")
            .HasColumnName("varchar(max)")
            .IsRequired();

        builder.Property(p => p.DateDelivery)
            .HasColumnName("DateDelivery")
            .HasColumnType("datetime")
            .IsRequired();      
    }   
}
