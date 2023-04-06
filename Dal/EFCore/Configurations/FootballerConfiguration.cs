using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EFCore.Configurations;

public class FootballerConfiguration: IEntityTypeConfiguration<Footballer>
{
    public void Configure(EntityTypeBuilder<Footballer> builder)
    {
        builder.Property(f => f.Id)
            .HasColumnName("id");
        
        builder.Property(f => f.FirstName)
            .IsRequired()
            .HasColumnName("firstname");

        builder.Property(f => f.LastName)
            .IsRequired()
            .HasColumnName("lastname");

        builder.Property(f => f.Gender)
            .IsRequired()
            .HasColumnName("gender");

        builder.Property(f => f.Birthday)
            .IsRequired()
            .HasColumnName("birthday");

        builder.Property(f => f.Country)
            .IsRequired()
            .HasColumnName("county");

        builder
            .HasOne(f => f.Team)
            .WithMany(t => t.Footballers)
            .HasForeignKey("team_id")
            .OnDelete(DeleteBehavior.SetNull);
    }
}