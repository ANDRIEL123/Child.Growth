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
        /// Retorna os dados de média P50 e peso
        /// </summary>
        /// <param name="childrenId"></param>
        /// <returns></returns>
        public IEnumerable<ComparativeAveragePercentileDTO> GetComparativeAveragePercentile(
            long childrenId,
            ChartTypeEnum chartType
        )
        {
            var children = _childrenRepository
                .Query(x => x.Id == childrenId)
                .FirstOrDefault();

            if (children == null)
                throw new BusinessException("Paciente não localizado.");

            var averages = GetChartDataAverageByType(children.Gender, chartType);
            var consults = GetConsultsByChartType(childrenId, chartType);

            foreach (var consult in consults)
            {
                var childrenMonthsOfLifeInConsult = GetLifeTimeInMonthsAtConsult(
                    children.BirthDate,
                    consult.Date
                );

                if (childrenMonthsOfLifeInConsult > (12 * 5))
                    throw new BusinessException($"São comparados somente pacientes de até 5 anos, na consulta do dia {consult.Date:dd/MM/yyyy} o paciente possuí mais: {childrenMonthsOfLifeInConsult} meses.");

                // Compara o tempo de vida em meses do paciente com os dados das planilhas
                var average = averages
                    .Where(x => x.Month == childrenMonthsOfLifeInConsult)
                    .Select(x => x.Average)
                    .FirstOrDefault();

                var comparativeAverage = new ComparativeAveragePercentileDTO
                {
                    Month = consult.Month,
                    Average = average,
                    PatientValue = consult.PatientValue
                };

                yield return comparativeAverage;
            }
        }
    }
}