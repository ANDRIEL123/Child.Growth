using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Infra.DTO;
using Child.Growth.src.Infra.Exceptions;
using Child.Growth.src.Infra.Enums;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        /// <summary>
        /// Geração dos dados para uso nos gráficos de z-scores
        /// </summary>
        /// <param name="childrenId"></param>
        /// <param name="chartType"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public IEnumerable<ZScoresDTO> GetZScores(
            long childrenId,
            ChartTypeEnum chartType
        )
        {
            var lastConsult = _repository
                .Query(x => x.ChildrenId == childrenId)
                .Select(x => new
                {
                    x.Date,
                    x.Children?.BirthDate,
                    x.Children?.Gender
                })
                .OrderBy(x => x.Date)
                .LastOrDefault();

            var lifeTimeInMonths = GetLifeTimeInMonthsAtConsult(
                lastConsult.BirthDate,
                lastConsult.Date
            );

            if (lifeTimeInMonths > (12 * 5))
                throw new BusinessException($"São comparados somente pacientes de até 5 anos, na consulta do dia {lastConsult.Date:dd/MM/yyyy} o paciente possuí mais: {lifeTimeInMonths} meses.");

            var consults = GetConsultsByChartType(childrenId, chartType);

            var scores = GetChartDataZScoreByType((GenderEnum)(lastConsult?.Gender), chartType)
                .Where(x => x.Month <= lifeTimeInMonths)
                .ToList();

            foreach (var consult in consults)
            {
                var score = scores
                    .Where(x => x.Month == consult.Date.Value.Month)
                    .FirstOrDefault();

                score.PatientValue = consult.PatientValue;

                yield return score;
            }
        }
    }
}