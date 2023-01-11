using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
    internal class PickupConfigurationModelConfiguration : IEntityTypeConfiguration<PickupConfiguration>
    {
        public void Configure(EntityTypeBuilder<PickupConfiguration> builder)
        {
            builder.ToTable("PickupConfigurations")
                .HasKey(p => p.Id)
                .HasName("PickupConfigurationId");

            builder.Property(p => p.Id)
                .HasColumnName("PickupConfigurationId");

            builder.Property(p => p.Name)
                .HasColumnName("PickupConfigurationName")
                .IsRequired();
        }
    }
}
