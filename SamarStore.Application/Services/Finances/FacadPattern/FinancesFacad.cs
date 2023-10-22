using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Finances.Commands.AddRequestPay;
using SamarStore.Application.Services.HomePage.Commands.AddNewSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Finances.FacadPattern
{
    public class FinancesFacad : IFinancesFacad
    {
        private readonly IDataBaseContext _context;
        public FinancesFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private AddRequestPayService _addRequestPay;
        public AddRequestPayService AddRequestPayService
        {
            get
            {
                return _addRequestPay = _addRequestPay ?? new AddRequestPayService(_context);
            }
        }
    }
}
