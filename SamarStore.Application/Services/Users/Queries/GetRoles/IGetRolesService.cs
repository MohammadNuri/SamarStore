using SamarStore.Application.Services.Users.Queries.GetRoles;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
