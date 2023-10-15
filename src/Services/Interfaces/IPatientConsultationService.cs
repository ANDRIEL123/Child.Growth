using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Base;

namespace Child.Growth.src.Services.Interfaces
{
    public interface IPatientConsultationService : IServiceBase<PatientConsultation>
    {
        ResponseBody GetConsultsByUserId(long userId);
    }
}