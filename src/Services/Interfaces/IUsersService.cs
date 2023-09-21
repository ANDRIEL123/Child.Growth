using Child.Growth.src.Entities;
using Child.Growth.src.Services.Base;

namespace Child.Growth.src.Services.Interfaces
{
    public interface IUsersService : IServiceBase<Users>
    {
        object Login(string email, string password);

        bool CheckIfTheUserExists(Users newUser);
    }
}