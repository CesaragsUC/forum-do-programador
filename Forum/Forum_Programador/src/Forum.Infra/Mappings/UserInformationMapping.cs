using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infra.Mappings
{
    public class UserInformationMapping : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.WebSite)
                .HasColumnType("varchar(100)");

            builder.Property(u => u.GitHub)
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Twitter)
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Instagran)
                .HasColumnType("varchar(100)");

            builder.Property(u => u.FaceBook)
                .HasColumnType("varchar(100)");


            builder.Property(u => u.NickName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Adress)
                .HasColumnType("varchar(100)");


            builder.Property(u => u.Occupation)
                .IsRequired()
                .HasColumnType("varchar(100)");



            builder.ToTable("UserInformation");
        }
    }
}
