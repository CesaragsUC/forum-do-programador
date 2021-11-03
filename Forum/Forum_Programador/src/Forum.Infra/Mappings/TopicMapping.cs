using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infra.Mappings
{
    public class TopicMapping : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(u => u.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            //1:1 user
            builder.HasOne(u => u.User);

            //1:N comments
            builder.HasMany(c => c.Coments)
                .WithOne(t => t.Topic)
                .HasForeignKey(t => t.TopicId);

            builder.ToTable("Topics");
        }
    }
}
