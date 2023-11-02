using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using ExcelDataReader;
using Child.Growth.src.Infra.DTO;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        /// <summary>
        /// Retorna uma lista de percentis (Mês e Média)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static List<PercentilesDTO> GetAveragePercentile(string filePath)
        {
            var percentiles = new List<PercentilesDTO>();

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            do
            {
                while (reader.Read())
                {
                    // Ignora o cabeçalho (primeira linha)
                    if (reader.Depth == 0)
                        continue;

                    var month = Convert.ToInt32(reader.GetValue(0)) + 1;
                    var average = Convert.ToSingle(reader.GetValue(11));

                    var percentil = new PercentilesDTO
                    {
                        Month = month,
                        Average = average
                    };

                    percentiles.Add(percentil);
                }
            } while (reader.NextResult());

            return percentiles;
        }
    }
}