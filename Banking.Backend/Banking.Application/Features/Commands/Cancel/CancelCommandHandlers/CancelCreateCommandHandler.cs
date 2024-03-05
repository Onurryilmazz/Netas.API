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
        
        var transaction = await _unitOfWork.TransactionRepository.GetTransactionByCancelRequest(request.Request);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail =
           await  _unitOfWork.TransactionDetailRepository.GetSingleAsync(x => x.TransactionId == transaction.ID);
        
        if (transactionDetail == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction detail not found";
            return response;
        }
        
        transaction.TranscationDate = DateTime.Now;
        transaction.NetAmount = 0;
        
        transactionDetail.TransactionTypeId = (int)TransactionTypeEnum.Cancel;
        
        await _unitOfWork.TransactionRepository.UpdateAsync(transaction);
        await _unitOfWork.TransactionDetailRepository.UpdateAsync(transactionDetail);
        _unitOfWork.Save();

        response.Message = "Transaction canceled successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(CancelGarantiCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();
        
        var transaction = await _unitOfWork.TransactionRepository.GetTransactionByCancelRequest(request.Request);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail =
            await  _unitOfWork.TransactionDetailRepository.GetSingleAsync(x => x.TransactionId == transaction.ID);
        
        if (transactionDetail == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction detail not found";
            return response;
        }
        
        transaction.TranscationDate = DateTime.Now;
        transaction.NetAmount = 0;
        
        transactionDetail.TransactionTypeId = (int)TransactionTypeEnum.Cancel;
        
        await _unitOfWork.TransactionRepository.UpdateAsync(transaction);
        await _unitOfWork.TransactionDetailRepository.UpdateAsync(transactionDetail);
        _unitOfWork.Save();

        response.Message = "Transaction canceled successfully";
        return response;
    }

    public async Task<ServiceResult> Handle(CancelYapiKrediCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();
        
        var transaction = await _unitOfWork.TransactionRepository.GetTransactionByCancelRequest(request.Request);
        
        if (transaction == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction not found";
            return response;
        }

        var transactionDetail =
            await  _unitOfWork.TransactionDetailRepository.GetSingleAsync(x => x.TransactionId == transaction.ID);
        
        if (transactionDetail == null)
        {
            response.IsSuccess = false;
            response.Message = "Transaction detail not found";
            return response;
        }
        
        transaction.TranscationDate = DateTime.Now;
        transaction.NetAmount = 0;
        
        transactionDetail.TransactionTypeId = (int)TransactionTypeEnum.Cancel;
        
        await _unitOfWork.TransactionRepository.UpdateAsync(transaction);
        await _unitOfWork.TransactionDetailRepository.UpdateAsync(transactionDetail);
        _unitOfWork.Save();

        response.Message = "Transaction canceled successfully";
        return response;
    }
}