using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Base;

namespace Child.Growth.src.Services.Interfaces
{
    public interface IResponsibleService : IServiceBase<Responsible>
    {
        ResponseBody GetOptions();

        ResponseBody CreateUserAndResponsible(Responsible responsible);

        ResponseBody DeleteUserAndResponsible(long responsibleId);
    }
}