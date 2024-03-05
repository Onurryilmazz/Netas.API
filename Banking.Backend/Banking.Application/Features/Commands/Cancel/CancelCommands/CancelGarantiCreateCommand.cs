using Banking.Application.Models.RequestModels;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Cancel.CancelCommands;

public class CancelGarantiCreateCommand :IRequest<ServiceResult>
{
    public CancelRequest Request { get; set; }
}