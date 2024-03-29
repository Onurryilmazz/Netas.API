using Banking.Application.Models.RequestModels;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Pay.PayCommands;

public class PayAkbankCreateCommand: IRequest<ServiceResult>
{
    public PayRequest Request { get; set; }
}