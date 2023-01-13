using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DAL.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
    internal sealed class TremoloTypeModelConfiguration : IEntityTypeConfiguration<TremoloType>
    {
        public void Configure(EntityTypeBuilder<TremoloType> builder)
        {
            builder.ToTable("TremoloTypes")
                .HasKey(p => p.Id)
                .HasName("TremoloId");

            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(max)")
                .IsRequired();
        }
    }
}
