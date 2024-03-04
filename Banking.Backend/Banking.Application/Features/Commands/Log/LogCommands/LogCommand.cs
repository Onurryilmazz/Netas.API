using Banking.Application.Models.ResponseModels;
using MediatR;

namespace Banking.Application.Features.Commands.Log.LogCommands;

public class LogCommand : IRequest<ServiceResult>
{
    public string Description { get; set; }
}