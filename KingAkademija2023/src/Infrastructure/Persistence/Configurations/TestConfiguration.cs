using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
	public class TestConfiguration : IEntityTypeConfiguration<Test>
	{
		public void Configure(EntityTypeBuilder<Test> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(64);

			//Auditable
			builder.Property(p => p.CreatedBy)
				.HasMaxLength(64)
				.IsUnicode()
				.IsRequired();

			builder.Property(p => p.LastModifiedBy)
				.HasMaxLength(64)
				.IsUnicode();

			builder.Property(p => p.Created)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			builder.Property(p => p.LastModified)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");
		}
	}
}
