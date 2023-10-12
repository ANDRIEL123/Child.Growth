using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Infra.Responses;

namespace Child.Growth.src.Services.Implementations
{
    public class ResponsibleService : ServiceBase<Responsible>, IResponsibleService
    {
        private readonly IRepository<Responsible> _repository;
        public ResponsibleService(
            IRepository<Responsible> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
        }

        public ResponseBody GetOptions()
        {
            var responsible = _repository
                .GetAll()
                .Select(x => new
                {
                    Label = x.Name,
                    Value = x.Id
                })
                .ToList();

            return new ResponseBody
            {
                Code = 200,
                Content = responsible
            };
        }
    }
}