namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal sealed class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        var navigation = builder.Metadata.FindNavigation(nameof(Basket.Items));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(b => b.BuyerId)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(p => p.CreateDate)
            .HasColumnType("datetime2(7)");

        builder.Property(p => p.UpdateDate)
            .HasColumnType("datetime2(7)");
    }
}
