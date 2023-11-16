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
        /// Retorna uma lista de z-scores
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static List<ZScoresDTO> GetXlsxZScores(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception($"Arquivo {filePath} não localizado");

            var scores = new List<ZScoresDTO>();

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

                    var zScores = new ZScoresDTO
                    {
                        Month = month,
                        ZScore3Negative = Convert.ToSingle(reader.GetValue(5)),
                        ZScore2Negative = Convert.ToSingle(reader.GetValue(6)),
                        ZScore1Negative = Convert.ToSingle(reader.GetValue(7)),
                        Average = Convert.ToSingle(reader.GetValue(8)),
                        ZScore1 = Convert.ToSingle(reader.GetValue(9)),
                        ZScore2 = Convert.ToSingle(reader.GetValue(10)),
                        ZScore3 = Convert.ToSingle(reader.GetValue(11)),
                        PatientValue = 0
                    };

                    scores.Add(zScores);
                }
            } while (reader.NextResult());

            return scores;
        }
    }
}