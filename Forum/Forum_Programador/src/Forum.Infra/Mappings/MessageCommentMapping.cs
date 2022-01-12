using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class MessageCommentMapping : IEntityTypeConfiguration<MessageComment>
    {
        public void Configure(EntityTypeBuilder<MessageComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).IsRequired().HasColumnType("text");

            //1:1
            builder.HasOne(c => c.PrivateMessages);

            //1:1
            builder.HasOne(u => u.User);


            builder.ToTable("MessageComment");
        }
    }
}
