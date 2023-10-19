using Child.Growth.src.Entities;
using Child.Growth.src.Infra.DTO;
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
        private readonly ILogger<PatientConsultationController> _logger;

        private readonly IPatientConsultationService _patientConsultationService;

        public PatientConsultationController(
            ILogger<PatientConsultationController> logger,
            IPatientConsultationService patientConsultationService,
            ITokenService tokenService
        )
        {
            _logger = logger;
            _patientConsultationService = patientConsultationService;
        }

        [HttpGet]
        [Authorize]
        public ResponseBody Get()
        {
            return _patientConsultationService.GetAll();
        }

        [HttpGet("GetByFilters")]
        [Authorize]
        public List<PatientConsultation> GetByFilters(string filters)
        {
            var PatientConsultationByFilter = _patientConsultationService.GetByFilters(filters);

            return PatientConsultationByFilter;
        }

        [HttpGet("GetConsultsByUserId")]
        [Authorize]
        public ResponseBody GetConsultsByUserId(long userId)
        {
            return _patientConsultationService.GetConsultsByUserId(userId);
        }

        [HttpGet("GetComparativeData")]
        [Authorize]
        public List<ComparativeData> GetComparativeData(long childrenId)
        {
            return _patientConsultationService.GetComparativeData(childrenId);
        }

        [HttpGet("GetComparativeAveragePercentileWeight")]
        [Authorize]
        public IEnumerable<ComparativeAveragePercentile> GetComparativeAveragePercentileWeight(long childrenId)
        {
            return _patientConsultationService.GetComparativeAveragePercentileWeight(childrenId);
        }

        [HttpPost]
        public ResponseBody Create([FromBody] PatientConsultation entity)
        {
            return _patientConsultationService.Create(entity);
        }

        [HttpPut]
        [Authorize]
        public ResponseBody Update([FromBody] PatientConsultation entity)
        {
            return _patientConsultationService.Update(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ResponseBody Delete(long id)
        {
            return _patientConsultationService.Delete(id);
        }
    }
}