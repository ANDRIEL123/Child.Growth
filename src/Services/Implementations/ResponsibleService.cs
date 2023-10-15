using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Infra.Enums;

namespace Child.Growth.src.Services.Implementations
{
    public class ResponsibleService : ServiceBase<Responsible>, IResponsibleService
    {
        private readonly IRepository<Responsible> _repository;
        private readonly IRepository<Users> _usersRepository;
        private readonly IUsersService _usersService;
        public ResponsibleService(
            IRepository<Responsible> repository,
            IRepository<Users> usersRepository,
            IUsersService usersService,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _usersService = usersService;
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

        /// <summary>
        /// Cria o usuário e o responsável
        /// </summary>
        /// <param name="responsible"></param>
        /// <returns></returns>
        public ResponseBody CreateUserAndResponsible(Responsible responsible)
        {
            var user = new Users
            {
                Name = responsible.Name,
                Email = responsible.Email,
                BirthDate = responsible.BirthDate,
                Phone = responsible.Phone,
                Type = UserTypeEnum.Responsible,
                Password = "responsavel", // Senha temporária
                Responsible = new List<Responsible>()
                {
                    responsible
                }
            };

            var res = _usersService.Create(user);

            return res;
        }

        /// <summary>
        /// Deleta o usuário e o responsável
        /// </summary>
        /// <param name="responsible"></param>
        /// <returns></returns>
        public ResponseBody DeleteUserAndResponsible(long responsibleId)
        {
            var userId = _repository
                    .GetAll()
                    .Where(x => x.Id == responsibleId)
                    .Select(x => x.UserId)
                    .FirstOrDefault();

            var response = _usersService.Delete(userId);

            return response;
        }
    }
}