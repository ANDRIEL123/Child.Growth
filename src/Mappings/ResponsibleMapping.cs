using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Child.Growth.src.Entities;

namespace Child.Growth.src.Mappings
{
    public class ResponsibleMapping : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.ToTable("responsible");

            builder
               .HasOne(p => p.User)
               .WithMany(c => c.Responsible)
               .HasForeignKey(p => p.UserId);
        }
    }
}