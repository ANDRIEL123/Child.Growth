using ExcelDataReader;
using Child.Growth.src.Infra.DTO;
using Child.Growth.src.Infra.Exceptions;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService
    {
        /// <summary>
        /// Retorna uma lista de percentis (Mês e Média)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static List<PercentilesDTO> GetAveragePercentile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new BusinessException($"Arquivo {filePath} não localizado");

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

                    var month = Convert.ToInt32(reader.GetValue(0));
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