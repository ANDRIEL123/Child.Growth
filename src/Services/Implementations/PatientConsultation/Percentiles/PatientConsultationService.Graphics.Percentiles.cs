using Child.Growth.src.Infra.DTO;
using Child.Growth.src.Infra.Exceptions;
using Child.Growth.src.Infra.Enums;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService
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
                    .Select(x => new
                    {
                        x.Average,
                        x.Month
                    })
                    .FirstOrDefault();

                var comparativeAverage = new ComparativeAveragePercentileDTO
                {
                    Month = average.Month.ToString(),
                    Average = average.Average,
                    PatientValue = consult.PatientValue
                };

                yield return comparativeAverage;
            }
        }
    }
}