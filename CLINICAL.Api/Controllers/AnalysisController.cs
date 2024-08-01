using CLINICAL.Domain;
using CLINICAL.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.RemoveCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQueryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AnalysisController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalysisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> AnalysisList()
    {
        var response = await _mediator.Send(new GetAllAnalysisQuery());
        return Ok(response);
    }
    [HttpGet("{AnalysisId:int}")]
    public async Task<ActionResult> AnalysisById(int AnalysisId)
    {
        var response = await _mediator.Send(new GetAllAnalysisQueryById() { AnalysisId = AnalysisId});
        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<ActionResult> AnalysisRegister([FromBody] CreateAnalysisCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Edit")]
    public async Task<ActionResult> AnalysisEdit([FromBody] UpdateAnalysisCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Remove/{analysisId:int}")]
    public async Task<ActionResult> AnalysisRemove(int analysisId)
    {
        var response = await _mediator.Send(new RemoveAnalysisCommand()
        {
            AnalysisId = analysisId
        });
        return Ok(response);
    }

    [HttpPut("ChangeState")]
    public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}