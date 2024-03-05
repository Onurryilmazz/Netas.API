using Banking.Application.Features.Commands.Refund.RefundCommands;
using Banking.Domain.Models;

namespace Banking.Application.Models.RequestModels;

public class RefundCreateRequest
{
    public RefundRequest Request { get; set; }

    public object GetRefundObject()
    {
        switch (Request.BankId)
        {
            case (int)BanksEnum.YapıKredi:
                return new RefundYapiKrediCreateCommand{Request = Request};
            case (int)BanksEnum.Akbank:
                return new RefundAkbankCreateCommand{Request = Request};
            case (int)BanksEnum.Garanti:
                return new RefundGarantiCreateCommand { Request = Request };
            default:
                throw new Exception("Bank not found");
        }
    }
}