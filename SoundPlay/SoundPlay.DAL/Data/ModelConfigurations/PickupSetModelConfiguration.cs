using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
    internal class PickupSetModelConfiguration : IEntityTypeConfiguration<PickupSet>
    {
        public void Configure(EntityTypeBuilder<PickupSet> builder)
        {
            builder.ToTable("PickupSets")
                .HasKey(p => p.Id)
                .HasName("PickupSetId");

            builder.Property(p => p.Id)
                .HasColumnName("PickupSetId");

            builder.Property(p => p.Name)
                .HasColumnName("PickupSetName")
                .IsRequired();
        }
    }
}
