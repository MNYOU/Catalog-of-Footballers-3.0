using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EFCore.Configurations;

public class TeamConfiguration: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.Property(t => t.Id)
            .HasColumnName("id");

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name");
    }
}