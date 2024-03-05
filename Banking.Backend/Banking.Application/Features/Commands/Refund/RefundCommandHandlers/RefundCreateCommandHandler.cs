using Banking.Application.Features.Commands.Refund.RefundCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using Banking.Domain.Models;
using MediatR;

namespace Banking.Application.Features.Commands.Refund.RefundCommandHandlers;

public class RefundCreateCommandHandler :IRequestHandler<RefundYapiKrediCreateCommand, ServiceResult>,
    IRequestHandler<RefundAkbankCreateCommand, ServiceResult>,
    IRequestHandler<RefundGarantiCreateCommand, ServiceResult>
{
    
    private readonly IUnitOfWork _unitOfWork;
    public RefundCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<ServiceResult> Handle(RefundYapiKrediCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();

        var transaction = await _unitOfWork.TransactionRepository.GetMaxIdTransactionWithOrder(request.Request.OrderId);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail = new TransactionDetail
        {
            Amount = request.Request.RefundAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Refund,
            StatusId = (int)StatusEnum.Success
        };

        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.YapıKredi,
            TranscationDate = DateTime.Now,
            NetAmount = transaction.NetAmount - request.Request.RefundAmount,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);
        _unitOfWork.Save();
        
        response.Message = "Transaction refunded successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(RefundAkbankCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();

        var transaction = await _unitOfWork.TransactionRepository.GetMaxIdTransactionWithOrder(request.Request.OrderId);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail = new TransactionDetail
        {
            Amount = request.Request.RefundAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Refund,
            StatusId = (int)StatusEnum.Success
        };

        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.Akbank,
            TranscationDate = DateTime.Now,
            NetAmount = transaction.NetAmount - request.Request.RefundAmount,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);
        _unitOfWork.Save();
        
        response.Message = "Transaction refunded successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(RefundGarantiCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();

        var transaction = await _unitOfWork.TransactionRepository.GetMaxIdTransactionWithOrder(request.Request.OrderId);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail = new TransactionDetail
        {
            Amount = request.Request.RefundAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Refund,
            StatusId = (int)StatusEnum.Success
        };

        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.Garanti,
            TranscationDate = DateTime.Now,
            NetAmount = transaction.NetAmount - request.Request.RefundAmount,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);
        _unitOfWork.Save();
        
        response.Message = "Transaction refunded successfully";
        return response;
    }
}