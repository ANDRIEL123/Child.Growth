using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Child.Growth.src.Entities;

namespace Child.Growth.src.Mappings
{
    public class ChildrenMapping : IEntityTypeConfiguration<Children>
    {
        public void Configure(EntityTypeBuilder<Children> builder)
        {
            builder.ToTable("children");
        }
    }
}