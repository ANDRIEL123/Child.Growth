using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Infra.DTO;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        public List<ZScoresDTO> GetZScores()
        {
            var scores = GetXlsxZScores("DataSets\\Boys\\z-scores\\height\\0_2.xlsx");

            return scores;
        }
    }
}