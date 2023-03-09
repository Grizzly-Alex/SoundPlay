namespace SoundPlay.Infrastructure.DataAccess.ModelConfigurations;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(max)")
            .IsRequired();
    }
}
