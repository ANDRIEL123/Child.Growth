using Child.Growth.src.Entities;
using Child.Growth.src.Infra.DTO;
using Child.Growth.src.Infra.Enums;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientConsultationController : ControllerBase
    {
        private readonly IPatientConsultationService _patientConsultationService;

        public PatientConsultationController(
            IPatientConsultationService patientConsultationService
        )
        {
            _patientConsultationService = patientConsultationService;
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Get()
        {
            return _patientConsultationService.GetAll();
        }

        [HttpGet("GetByFilters")]
        [Authorize(Roles = "Doctor")]
        public List<PatientConsultation> GetByFilters(string filters)
        {
            var PatientConsultationByFilter = _patientConsultationService.GetByFilters(filters);

            return PatientConsultationByFilter;
        }

        [HttpGet("GetConsultsByUserId")]
        [Authorize(Roles = "Doctor,Responsible")]
        public ResponseBody GetConsultsByUserId(long userId)
        {
            return _patientConsultationService.GetConsultsByUserId(userId);
        }

        [HttpGet("GetGraphComparativeData")]
        [Authorize(Roles = "Doctor")]
        public List<ComparativeData> GetGraphComparativeData(long childrenId)
        {
            return _patientConsultationService.GetComparativeData(childrenId);
        }

        [HttpGet("GetComparativeAveragePercentile")]
        [Authorize(Roles = "Doctor")]
        public IEnumerable<ComparativeAveragePercentileDTO> GetComparativeAveragePercentile(
            long childrenId,
            ChartTypeEnum chartType
        )
        {
            return _patientConsultationService.GetComparativeAveragePercentile(childrenId, chartType);
        }

        [HttpGet("GetZSCoresData")]
        [Authorize(Roles = "Doctor")]
        public IEnumerable<ZScoresDTO> GetZSCoresData(long childrenId, ChartTypeEnum chartType)
        {
            return _patientConsultationService.GetZScores(childrenId, chartType);
        }

        [HttpPost]
        public ResponseBody Create([FromBody] PatientConsultation entity)
        {
            return _patientConsultationService.Create(entity);
        }

        [HttpPut]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Update([FromBody] PatientConsultation entity)
        {
            return _patientConsultationService.Update(entity);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Delete(long id)
        {
            return _patientConsultationService.Delete(id);
        }
    }
}