using Banking.Application.Models.RequestModels;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Refund.RefundCommands;

public class RefundAkbankCreateCommand : IRequest<ServiceResult>
{
    public RefundRequest Request { get; set; }
}
