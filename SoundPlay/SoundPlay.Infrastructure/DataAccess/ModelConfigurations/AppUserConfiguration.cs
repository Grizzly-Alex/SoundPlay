namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.StreetAddress)
            .HasColumnName("street_address")
            .HasColumnType("varchar(max)");

        builder.Property(p => p.City)
            .HasColumnName("city")
            .HasColumnType("varchar(max)");

        builder.Property(p => p.State)
            .HasColumnName("state")
            .HasColumnType("varchar(max)");

        builder.Property(p => p.PostalCode)
            .HasColumnName("postal_code")
            .HasColumnType("varchar(max)");
    }
}
