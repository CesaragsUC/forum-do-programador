using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class TopicViewsMapping : IEntityTypeConfiguration<TopicViews>
    {
        public void Configure(EntityTypeBuilder<TopicViews> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.TopicId)
                .IsRequired();

            builder.Property(u => u.UserId)
                .IsRequired();


            builder.ToTable("TopicViews");
           
        }
    }
}
