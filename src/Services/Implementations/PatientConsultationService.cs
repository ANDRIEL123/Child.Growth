using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Infra.Responses;

namespace Child.Growth.src.Services.Implementations
{
    public partial class PatientConsultationService : ServiceBase<PatientConsultation>, IPatientConsultationService
    {
        private readonly IRepository<PatientConsultation> _repository;
        public PatientConsultationService(
            IRepository<PatientConsultation> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna os dados das consultas de um usuário 
        /// vinculado a um responsável vinculado a criança
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResponseBody GetConsultsByUserId(long userId)
        {
            var consults = _repository
                .Query(x =>
                    x.Children.Responsible.UserId == userId
                )
                .ToList();

            return new ResponseBody
            {
                Code = 200,
                Content = consults,
                Message = "Dados de consulta retornados"
            };
        }
    }
}