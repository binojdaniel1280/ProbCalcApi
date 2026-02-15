using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProbabilityController : ControllerBase
{
    private readonly ProbabilityEngine _engine;
    private readonly IOperationProvider _provider;

    public ProbabilityController(
        ProbabilityEngine engine,
        IOperationProvider provider)
    {
        _engine = engine;
        _provider = provider;
    }

    [HttpGet("operations")]
    public IActionResult GetOperations()
    {
        return Ok(_provider.GetOperations());
    }

    [HttpPost("calculate")]
    public IActionResult Calculate(ProbabilityRequest req)
    {
        var result = _engine.Execute(req);
        return Ok(result);
    }
}
