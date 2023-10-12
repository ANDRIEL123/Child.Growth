using Child.Growth.src.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Child.Growth.src.Infra.DependencyInjection
{
    public class InjectMappings
    {
        public static void Add(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMapping());
            modelBuilder.ApplyConfiguration(new ChildrenMapping());
            modelBuilder.ApplyConfiguration(new PatientConsultationMapping());
            modelBuilder.ApplyConfiguration(new ResponsibleMapping());
        }
    }
}