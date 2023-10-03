using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;

namespace Child.Growth.src.Services.Implementations
{
    public class ChildrenService : ServiceBase<Children>, IChildrenService
    {
        public ChildrenService(
            IRepository<Children> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
        }
    }
}