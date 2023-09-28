using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Users.Commands.EditUser
{
    public partial class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context)
        {
            _context = context; 
        }
        public ResultDto Execute(RequestEditUserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            user.Email = request.Email;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }

}
