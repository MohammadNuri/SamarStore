using SamarStore.Application.Services.Finances.Commands.AddRequestPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IFinancesFacad
    {
        AddRequestPayService AddRequestPayService { get; }
    }
}
