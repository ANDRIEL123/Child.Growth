using Child.Growth.src.Entities;

namespace Child.Growth.src.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<Users> GetAll();

        void Create(Users user);
    }
}