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
    public class RankingMapping : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CommentId)
                .IsRequired();

            builder.Property(r => r.Point)
                .IsRequired();

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.UserSentPointId)
                .IsRequired();

            builder.ToTable("Rankings");
        }
    }
}
