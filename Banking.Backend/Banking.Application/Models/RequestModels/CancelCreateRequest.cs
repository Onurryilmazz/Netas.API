using Banking.Application.Features.Commands.Cancel.CancelCommands;
using Banking.Domain.Models;

namespace Banking.Application.Models.RequestModels;

public class CancelCreateRequest
{
    public CancelRequest request{ get; set; }

    public object GetCancelRequest()
    {
        switch (request.BankId)
        {
            case (int)BanksEnum.Akbank:
                return new CancelAkbankCreateCommand{Request = request};
            case (int)BanksEnum.Garanti:
                return new CancelGarantiCreateCommand{Request = request};
            case (int)BanksEnum.YapıKredi:
                return new CancelYapiKrediCreateCommand{Request = request};
            default:
                throw new Exception("Bank not found");
                
        }
    }
}