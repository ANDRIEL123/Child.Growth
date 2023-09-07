using Child.Growth.src.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Repositories.Interfaces.Base;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users> _repository;
        private readonly IUnitOfWork _uow;

        public UsersService(IRepository<Users> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public IEnumerable<Users> GetAll()
        {
            var users = _repository.GetAll();

            return users;
        }
    }
}