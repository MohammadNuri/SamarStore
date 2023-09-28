using SamarStore.Common.Dto;
using static SamarStore.Application.Services.Users.Commands.EditUser.EditUserService;

namespace SamarStore.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }

}
