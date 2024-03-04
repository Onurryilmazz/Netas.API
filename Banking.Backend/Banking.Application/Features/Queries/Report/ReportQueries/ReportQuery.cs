using Banking.Application.Models.RequestModels;
using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Queries.Report.ReportQueries;

public class ReportQuery : IRequest<ServiceResult<List<ReportResponse>>>
{
    public ReportFilterRequest Request { get; set; }
}