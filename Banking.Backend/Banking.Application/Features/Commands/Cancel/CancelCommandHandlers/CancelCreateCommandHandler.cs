using Banking.Application.Features.Commands.Cancel.CancelCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Cancel.CancelCommandHandlers;

public class CancelCreateCommandHandler :IRequestHandler<CancelCreateCommand, ServiceResult>
{
    
    private readonly IUnitOfWork _unitOfWork;
    public CancelCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<ServiceResult> Handle(CancelCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}