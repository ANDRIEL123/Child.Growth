using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Infra.Enums;
using Child.Growth.src.Infra.DTO;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        private string baseDataSets = "DataSets";

        /// <summary>
        /// Retorna o tempo de vida em meses com base 
        /// no aniversário e na data da consulta
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="consultDate"></param>
        /// <returns></returns>
        private static int GetLifeTimeInMonthsAtConsult(
            DateTime? birthDate,
            DateTime? consultDate
        )
        {
            if (!birthDate.HasValue)
                return 0;

            var years = consultDate.Value.Year - birthDate.Value.Year;
            var months = consultDate.Value.Month - birthDate.Value.Month;

            if (years > 0)
                return ((years + 1) * 12) + months;

            // Meses começam em 0 nas planilhas
            return months - 1;
        }

        /// <summary>
        /// Retorna as consultas do paciente dependendo do tipo de gráfico
        /// </summary>
        /// <param name="childrenId"></param>
        /// <param name="chartType"></param>
        /// <returns></returns>
        private List<ComparativeAveragePercentileConsultDTO> GetConsultsByChartType(
            long childrenId,
            ChartTypeEnum chartType
        )
        {
            return _repository
                .Query(x => x.ChildrenId == childrenId)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => new { x.Date.Month, x.Date.Year })
                .Select(x => new ComparativeAveragePercentileConsultDTO
                {
                    Month = $"{x.Key.Month:00}/{x.Key.Year}",
                    PatientValue = GetPatientValueByChartType(x.Last(), chartType),
                    Date = x.Last().Date
                })
                .Reverse()
                .ToList();
        }

        /// <summary>
        /// Retorna o valor dependendo do tipo de gráfico
        /// </summary>
        /// <param name="patientConsultation"></param>
        /// <param name="chartType"></param>
        /// <returns></returns>
        private static float GetPatientValueByChartType(
            PatientConsultation patientConsultation,
            ChartTypeEnum chartType
        )
        {
            return
            chartType switch
            {
                ChartTypeEnum.Weight => patientConsultation.Weight,
                ChartTypeEnum.Height => patientConsultation.Height,
                ChartTypeEnum.CephalicPerimeter => patientConsultation.CephalicPerimeter,
                _ => 0,
            };
        }

        /// <summary>
        /// Retorna os dados da planilha com base no tipo de gráfico para percentil
        /// Peso, altura e perímetro cefálico
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="chartType"></param>
        /// <returns></returns>
        private List<PercentilesDTO> GetChartDataAverageByType(
            GenderEnum gender,
            ChartTypeEnum chartType
        )
        {
            var folderName = GetFolderNameByChartType(chartType);
            return GetAveragePercentile(GetFilePath(folderName, "percentiles", gender));
        }

        /// <summary>
        /// Retorna os dados da planilha com base no tipo de gráfico para z-score
        /// Peso, altura e perímetro cefálico
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="chartType"></param>
        /// <returns></returns>
        private List<ZScoresDTO> GetChartDataZScoreByType(
            GenderEnum gender,
            ChartTypeEnum chartType
        )
        {
            var folderName = GetFolderNameByChartType(chartType);
            return GetXlsxZScores(GetFilePath(folderName, "z-scores", gender));
        }

        /// <summary>
        /// Retorna o nome da pasta com base no tipo de gráfico
        /// </summary>
        /// <param name="chartType"></param>
        /// <returns></returns>
        private static string GetFolderNameByChartType(ChartTypeEnum chartType)
        {
            return chartType switch
            {
                ChartTypeEnum.Weight => "weight",
                ChartTypeEnum.Height => "height",
                ChartTypeEnum.CephalicPerimeter => "cephalic_perimeter",
                _ => string.Empty,
            };
        }

        /// <summary>
        /// Retorna o caminho da planilha
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="type"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        private static string GetFilePath(
            string folderName,
            string type,
            GenderEnum gender
        )
        {
            var stringGender = gender == GenderEnum.Male ? "Boys" : "Girls";
            var BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(BaseDirectory, "DataSets", stringGender, type, folderName, "0_5.xlsx");
        }
    }
}