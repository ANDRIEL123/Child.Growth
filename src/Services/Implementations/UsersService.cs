using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Infra.Exceptions;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Infra.Responses;

namespace Child.Growth.src.Services.Implementations
{
    public class UsersService : ServiceBase<Users>, IUsersService
    {
        private readonly IRepository<Users> _repository;
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _tokenService;

        public UsersService(
            IRepository<Users> repository,
            IUnitOfWork uow,
            ITokenService tokenService
        ) : base(repository, uow)
        {
            _repository = repository;
            _uow = uow;
            _tokenService = tokenService;
        }

        public new ResponseBody Create(Users entity)
        {
            if (CheckIfTheUserExists(entity))
                throw new Exception("Já existe um usuário com esse e-mail");

            return base.Create(entity);
        }

        /// <summary>
        /// Realiza o login na aplicação retornando o Token JWT Bearer
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public object Login(string email, string password)
        {
            if (!CheckCredentials(email, password))
                throw new Exception("Credenciais invalidas.");

            return _tokenService.GenerateToken(email);
        }

        /// <summary>
        /// Verifica as credencias de acesso do usuário
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckCredentials(string email, string password)
        {
            var user = _repository
                .GetAll()
                .Where(x =>
                    x.Email == email &&
                    x.Password == password
                )
                .FirstOrDefault();

            if (user == null || string.IsNullOrEmpty(email))
                return false;

            return true;
        }

        /// <summary>
        /// Verifica se o usuário existe
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CheckIfTheUserExists(Users newUser)
        {
            var user = _repository
                .GetAll()
                .Where(x => x.Email == newUser?.Email)
                .FirstOrDefault();

            if (user != null)
                return true;

            return false;
        }
    }
}