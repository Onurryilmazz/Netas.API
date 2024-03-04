using Banking.Application.Features.Commands.Cancel.CancelCommands;
using Banking.Application.Features.Commands.Pay.PayCommandHandlers;
using Banking.Application.Features.Commands.Pay.PayCommands;
using Banking.Application.Features.Commands.Refund.RefundCommands;
using Banking.Application.Features.Queries.Report.ReportQueries;
using Banking.Application.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankingController : ControllerBase
{
    
    private readonly IMediator _mediator;
    public BankingController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Pay(PayRequest request)
    {
        var response = await _mediator.Send(new PayCreateCommand{  Request= request }); ;
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Cancel()
    {
        // var response = await _mediator.Send(new CancelCreateCommand{  Request= request }); ;
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Refund()
    {
        // var response = await _mediator.Send(new RefundCreateCommand{  Request= request }); ;
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Report(ReportFilterRequest request)
    {
        var response = await _mediator.Send(new ReportQuery{  Request= request }); ;
        return Ok(response);
    }
}