using Banking.Application.Features.Commands.Refund.RefundCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Refund.RefundCommandHandlers;

public class RefundCreateCommandHandler :IRequestHandler<RefundCreateCommand, ServiceResult>
{
    
    private readonly IUnitOfWork _unitOfWork;
    public RefundCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<ServiceResult> Handle(RefundCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}