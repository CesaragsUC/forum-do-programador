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
    public class CommentMapping : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(c => c.CommentId)
                 .IsRequired();

            //1:1
            builder.HasOne(u => u.User);

            //1:1
            builder.HasOne(t => t.Topic);


            builder.ToTable("Comments");

        }
    }
}
