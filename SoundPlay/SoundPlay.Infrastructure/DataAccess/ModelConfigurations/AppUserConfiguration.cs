namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.StreetAddress)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.City)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.State)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.PostalCode)
            .HasColumnType("varchar(max)");
    }
}
