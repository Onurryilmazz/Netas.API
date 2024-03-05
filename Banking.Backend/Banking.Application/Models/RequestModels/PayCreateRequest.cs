using Banking.Application.Features.Commands.Pay.PayCommands;
using Banking.Domain.Models;

namespace Banking.Application.Models.RequestModels;

public class PayCreateRequest
{
    public PayRequest Request { get; set; }

    public object GetCreateObject()
    {
        switch (Request.BankId)
        {
            case (int)BanksEnum.Akbank:
                return new PayAkbankCreateCommand { Request = Request };
            case (int)BanksEnum.YapıKredi:
                return new PayYapiKrediCreateCommand { Request = Request };
            case (int)BanksEnum.Garanti:
                return new PayGarantiCreateCommand { Request = Request };
            default:
                throw new Exception("Bank not found");
        }
    }
    
}