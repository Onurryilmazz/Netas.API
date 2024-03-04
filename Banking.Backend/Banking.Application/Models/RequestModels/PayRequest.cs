using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Models.RequestModels;

public class PayRequest : IRequest<ServiceResult>
{
    public int BankId { get; set; }
    public int Amount { get; set; }
}