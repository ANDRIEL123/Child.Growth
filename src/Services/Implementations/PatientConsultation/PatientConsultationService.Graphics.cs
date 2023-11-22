using Child.Growth.src.Infra.DTO;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService
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
    }
}