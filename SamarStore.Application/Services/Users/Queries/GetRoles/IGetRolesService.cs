using SamarStore.Application.Services.Users.Queries.GetRoles;
using SamarStore.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
