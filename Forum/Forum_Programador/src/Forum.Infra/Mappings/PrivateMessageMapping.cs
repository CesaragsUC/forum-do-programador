using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class PrivateMessageMapping : IEntityTypeConfiguration<PrivateMessages>
    {
        public void Configure(EntityTypeBuilder<PrivateMessages> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.SenderId)
                .IsRequired();

            builder.Property(u => u.RecipientId)
                .IsRequired();


            builder.Property(u => u.Subject)
                .IsRequired()
                .HasColumnType("varchar(100)");

            //1:N
            builder.HasMany(x => x.MessageComments)
                .WithOne(x => x.PrivateMessages)
                .HasForeignKey(x => x.PrivateMessageId);

            //1:1
            builder.HasOne(x => x.Sender);

            //1:1
            builder.HasOne(x => x.Recipient);

            //1:1
            builder.HasOne(x => x.Recipient);

            builder.ToTable("PrivateMessages");
           
        }
    }
}
