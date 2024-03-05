using Banking.Application.Features.Commands.Cancel.CancelCommands;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using Banking.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Banking.Application.Features.Commands.Cancel.CancelCommandHandlers;

public class CancelCreateCommandHandler : IRequestHandler<CancelAkbankCreateCommand, ServiceResult>,
    IRequestHandler<CancelGarantiCreateCommand, ServiceResult>,
    IRequestHandler<CancelYapiKrediCreateCommand, ServiceResult>
{
    
    private readonly IUnitOfWork _unitOfWork;
    public CancelCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<ServiceResult> Handle(CancelAkbankCreateCommand request, CancellationToken cancellationToken)
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
            Amount = transaction.NetAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Cancel,
            StatusId = (int)StatusEnum.Success
        };
        
        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.Akbank,
            TranscationDate = DateTime.Now,
            NetAmount = 0,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);

        response.Message = "Transaction canceled successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(CancelGarantiCreateCommand request, CancellationToken cancellationToken)
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
            Amount = transaction.NetAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Cancel,
            StatusId = (int)StatusEnum.Success
        };
        
        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.Garanti,
            TranscationDate = DateTime.Now,
            NetAmount = 0,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);

        response.Message = "Transaction canceled successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(CancelYapiKrediCreateCommand request, CancellationToken cancellationToken)
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
            Amount = transaction.NetAmount,
            TransactionId = transaction.ID,
            TransactionTypeId = (int)TransactionTypeEnum.Cancel,
            StatusId = (int)StatusEnum.Success
        };
        
        var newTransaction = new Transaction
        {
            BankID = (int)BanksEnum.YapıKredi,
            TranscationDate = DateTime.Now,
            NetAmount = 0,
            OrderReferenceId = transaction.OrderReferenceId,
            TotalAmount = transaction.TotalAmount,
            StatusID = (int)StatusEnum.Success
        };
        
        
        await _unitOfWork.TransactionDetailRepository.AddAsync(transactionDetail);
        await _unitOfWork.TransactionRepository.AddAsync(newTransaction);
        await _unitOfWork.TransactionRepository.UpdateOrderNetAmount(request.Request.OrderId,newTransaction.NetAmount);
        _unitOfWork.Save();

        response.Message = "Transaction canceled successfully";
        return response;
    }
}