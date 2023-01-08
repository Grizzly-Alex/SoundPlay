using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundPlay.DTO.Models;

namespace SoundPlay.DAL.Data.ModelConfigurations
{
	internal class TremoloTypeModelConfiguration : IEntityTypeConfiguration<TremoloType>
	{
		public void Configure(EntityTypeBuilder<TremoloType> builder)
		{
			builder.ToTable("TremoloTypes")
				.HasKey(p => p.Id)
				.HasName("TremoloId");

			builder.Property(p => p.Id)
				.HasColumnName("TremoloId");

			builder.Property(p => p.Name)
				.HasColumnName("TremoloName")
				.HasColumnType("varchar(30)")
				.IsRequired();
		}
	}
}