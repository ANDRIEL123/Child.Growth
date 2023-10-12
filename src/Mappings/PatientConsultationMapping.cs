using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Child.Growth.src.Entities;

namespace Child.Growth.src.Mappings
{
    public class PatientConsultationMapping : IEntityTypeConfiguration<PatientConsultation>
    {
        public void Configure(EntityTypeBuilder<PatientConsultation> builder)
        {
            builder.ToTable("patient_consultation");

            builder
               .HasOne(p => p.Children)
               .WithMany(c => c.Consultations)
               .HasForeignKey(p => p.ChildrenId);
        }
    }
}