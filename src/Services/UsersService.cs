using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Repositories.Interfaces.Base;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Infra.Exceptions;

namespace Child.Growth.src.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users> _repository;
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _tokenService;

        public UsersService(
            IRepository<Users> repository,
            IUnitOfWork uow,
            ITokenService tokenService
        )
        {
            _repository = repository;
            _uow = uow;
            _tokenService = tokenService;
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
                throw new BusinessException("Credenciais invalidas.");

            return _tokenService.GenerateToken(email);
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetAll()
        {
            var users = _repository.GetAll();

            return users;
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="user"></param>
        public void Create(Users user)
        {
            _repository.Add(user);

            _uow.SaveChanges();
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

            if (user == null)
                return false;

            return true;
        }
    }
}