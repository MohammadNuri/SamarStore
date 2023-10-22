using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Finances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Finances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);
    }

    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDataBaseContext _context;
        public AddRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);

            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,    
                Guid = Guid.NewGuid(),  
                IsPaid = false,
                User = user,
            };   
            _context.RequestPay.Add(requestPay);
            _context.SaveChanges(); 

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto()
                {
                    Guid = requestPay.Guid,

                },
                IsSuccess = true,
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid Guid { get; set; }
    }
}
