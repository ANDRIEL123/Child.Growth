using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        /// <summary>
        /// Retorna o tempo de vida em meses com base na data de nascimento
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        private static int GetLifeTimeInMonths(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
                return 0;

            var currentDate = DateTime.Now;

            var years = currentDate.Year - birthDate.Value.Year;
            var months = currentDate.Month - birthDate.Value.Month;

            if (years > 0)
                return ((years + 1) * 12) + months;

            return months;
        }
    }
}