using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class ReportuserMapping : IEntityTypeConfiguration<ReportUsers>
    {
        public void Configure(EntityTypeBuilder<ReportUsers> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserSendReportId).IsRequired();
            builder.Property(x => x.Reason).IsRequired().HasColumnType("varchar(500)");

            builder.ToTable("ReportUsers");

        }
    }
}
