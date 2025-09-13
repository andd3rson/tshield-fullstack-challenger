using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Api.Infra.Configurations;

public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("tb_task");

        builder.HasKey(pk => pk.Id)
            .HasName("code");

        builder.Property(x=>x.Id)
            .UseIdentityColumn();

        builder.Property(pk => pk.Description)
            .IsRequired(false)
            .HasColumnName("description")
            .HasColumnType("varchar(300)");

        builder.Property(pk => pk.IsDone)
            .IsRequired()            
            .HasColumnName("done")
            .HasColumnType("bit");

        builder.Property(pk => pk.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("varchar(100)");
      
    }
}
