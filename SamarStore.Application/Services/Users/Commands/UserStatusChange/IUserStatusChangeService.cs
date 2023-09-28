using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}
