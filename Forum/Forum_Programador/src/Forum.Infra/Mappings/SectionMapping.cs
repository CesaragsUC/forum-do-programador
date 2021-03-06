using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class SectionMapping : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(s => s.IsActive)
            .IsRequired()
            .HasColumnType("bit");

            //1:N
            builder.HasOne(x => x.Areas)
                .WithMany(x => x.Sections);

            builder.ToTable("Sections");
        }
    }
}
