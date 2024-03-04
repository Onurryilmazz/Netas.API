using Banking.Application.Features.Commands.Log.LogCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Log.LogCommandHandlers;

public class LogCommandHandler : IRequestHandler<LogCommand, ServiceResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public LogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResult> Handle(LogCommand request, CancellationToken cancellationToken)
    {
        var result = new ServiceResult();
        
        var log = new Domain.Models.Log()
        {
            CreatedDate = DateTime.Now,
            Description = request.Description,
        };

        await _unitOfWork.LogRepository.AddAsync(log);
        _unitOfWork.Save();
        return result;
    }
}