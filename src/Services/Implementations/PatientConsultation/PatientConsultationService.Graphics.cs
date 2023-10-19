using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Infra.DTO;
using Child.Growth.src.Infra.Exceptions;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        /// <summary>
        /// Retorna os dados para o gráfico de comparação 
        /// de crescimento das últimas 10 consultas
        /// </summary>
        /// <param name="childrenId">
        /// <returns></returns>
        public List<ComparativeData> GetComparativeData(long childrenId)
        {
            return _repository
                .Query(x => x.ChildrenId == childrenId)
                .OrderByDescending(x => x.Date)
                .Take(10)
                .Select(x => new ComparativeData
                {
                    Date = x.Date.ToString("dd/MM/yyyy"),
                    CephalicPerimeter = x.CephalicPerimeter,
                    Height = x.Height,
                    Weight = x.Weight
                })
                .Reverse()
                .ToList();
        }

        /// <summary>
        /// Retorna os dados de média P50 e peso
        /// </summary>
        /// <param name="childrenId"></param>
        /// <returns></returns>
        public IEnumerable<ComparativeAveragePercentile> GetComparativeAveragePercentileWeight(
            long childrenId
        )
        {
            var children = _childrenRepository
                .Query(x => x.Id == childrenId)
                .FirstOrDefault();

            if (children == null)
                throw new BusinessException("Paciente não localizado.");

            var childrenMonthsOfLife = GetLifeTimeInMonths(children.BirthDate);
            var weightAverages = GetAveragePercentile("DataSets\\Boys\\tab_wfa_boys_p_0_5.xlsx");

            var consults = _repository
                .Query(x => x.ChildrenId == childrenId)
                .OrderByDescending(x => x.Date)
                .Take(10)
                .GroupBy(x => x.Date.Month)
                .Select(x => new
                {
                    Month = x.Key,
                    x.Last().Date.Year,
                    x.Last().Weight
                })
                .Reverse()
                .ToList();

            if (childrenMonthsOfLife > (12 * 5))
                throw new BusinessException("São comparados somente pacientes de até 5 anos");

            foreach (var consult in consults)
            {
                var average = weightAverages
                    .Where(x => x.Month == consult.Month)
                    .Select(x => x.Average)
                    .FirstOrDefault();

                var comparativeAverage = new ComparativeAveragePercentile
                {
                    Month = $"{consult.Month:00}/{consult.Year}",
                    Average = average,
                    PatientValue = consult.Weight
                };

                yield return comparativeAverage;
            }
        }
    }
}