using Banking.Application.Features.Queries.Report.ReportQueries;
using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.ResponseModels;
using MediatR;

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

        var banks = _unitOfWork.BankRepository.GetAllAsync().Result;
        var status = _unitOfWork.StatuRepository.GetAllAsync().Result;
        
        var bankId = banks.FirstOrDefault(x => x.Name == request.Request.BankName).ID;
        var statusId = status.FirstOrDefault(x => x.StatuName == request.Request.StatuName).Id;
        
        
        var transactions = _unitOfWork.TransactionRepository.GetWhereAsync(x=>x.BankID == bankId && x.StatusID == statusId).Result;

        var report = transactions.Select(x => new ReportResponse
        {
            BankId = x.BankID,
            Amount = x.NetAmount
        }).ToList();
        
        result.Data = report;

        return result;
    }
}