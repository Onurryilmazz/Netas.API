using Banking.Application.Features.Commands.Pay.PayCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.RequestModels;
using Banking.Application.Models.ResponseModels;
using Banking.Domain.Models;
using MediatR;

namespace Banking.Application.Features.Commands.Pay.PayCommandHandlers;

public class PayCreateCommandHandler :IRequestHandler<PayCreateCommand, ServiceResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public PayCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult> Handle(PayCreateCommand request, CancellationToken cancellationToken)
    {
        var result = new ServiceResult();

        
        var transaction = new Domain.Models.Transaction
        {
            BankID = request.Request.BankId,
            TotalAmount = request.Request.Amount,
            NetAmount = request.Request.Amount ,
            StatusID = (int)StatusEnum.Success,
            TranscationDate = DateTime.Now
        };
        
        await _unitOfWork.TransactionRepository.AddAsync(transaction);
        _unitOfWork.Save();
        
        var transactionDetail = new Domain.Models.TransactionDetail
        {
            TransactionId = transaction.ID,
            Amount = request.Request.Amount,
            StatusId = (int)StatusEnum.Success,
            TransactionTypeId = (int)TransactionTypeEnum.Sale
        };
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        _unitOfWork.Save();
        
        return result;
    }
}