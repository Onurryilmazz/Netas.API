using Banking.Application.Features.Queries.Report.ReportQueries;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Banking.Application.Features.Queries.Report.ReportQueryHandler;

public class ReportQueryHandler : IRequestHandler<ReportQuery, ServiceResult<List<ReportResponse>>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    public ReportQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async  Task<ServiceResult<List<ReportResponse>>> Handle(ReportQuery request, CancellationToken cancellationToken)
    {
        var result = new ServiceResult<List<ReportResponse>>();

        var transactions = _unitOfWork.TransactionRepository.GetAllAsync().Result
            .Join(_unitOfWork.BankRepository.GetAllAsync().Result,
                transaction => transaction.BankID,
                bank => bank.ID,
                ((transaction, bank) => new { Transaction = transaction, Bank = bank }))
            .Join(_unitOfWork.StatuRepository.GetAllAsync().Result,
                transaction => transaction.Transaction.StatusID,
                statu => statu.Id,
                ((transactions, status) => new { Transactions = transactions, Statu = status }));

        if (request.Request.BankName != null)
        {
            transactions = transactions.Where(x => x.Transactions.Bank.Name == request.Request.BankName);
        }

        if (request.Request.StatuName != null)
        {
            transactions = transactions.Where(x => x.Statu.StatuName == request.Request.StatuName);
        }

        if (request.Request.StartDateTime != null)
        {
            transactions = transactions.Where(x => x.Transactions.Transaction.TranscationDate.Date >= request.Request.StartDateTime.Date);
        }
        
        if (request.Request.EndDateTime != null)
        {
            transactions = transactions.Where(x => x.Transactions.Transaction.TranscationDate.Date <= request.Request.EndDateTime.Date);
        }

        if (request.Request.OrderReferenceId != null)
        {
            transactions = transactions.Where(x => x.Transactions.Transaction.OrderReferenceId == request.Request.OrderReferenceId);
        }
        
        var report = await transactions.Select(x => new ReportResponse
        {
            BankId = x.Transactions.Bank.ID,
            NetAmount = x.Transactions.Transaction.NetAmount,
            TransactionId = x.Transactions.Transaction.ID,
        }).ToListAsync();
        
        result.Data = report;

        return result;
    }
}