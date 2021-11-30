using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Forum.Infra.Mappings
{
    public class UserFriendMapping : IEntityTypeConfiguration<UserFriends>
    {
        public void Configure(EntityTypeBuilder<UserFriends> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.UserId).IsRequired();
            
            builder.Property(x => x.FriendId).IsRequired();

            builder.ToTable("UserFriends");
        }
    }
}
