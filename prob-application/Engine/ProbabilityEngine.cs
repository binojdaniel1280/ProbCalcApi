public class ProbabilityEngine
{
    private readonly IEnumerable<IProbabilityOperation> _operations;
    private readonly ILogService _log;

    public ProbabilityEngine(
        IEnumerable<IProbabilityOperation> operations,
        ILogService log)
    {
        _operations = operations;
        _log = log;
    }

    public ProbabilityResult Execute(ProbabilityRequest req)
    {
        if (req.A < 0 || req.A > 1 || req.B < 0 || req.B > 1)
            throw new Exception("Probabilities must be between 0 and 1.");

        var operation = _operations.FirstOrDefault(o => o.Code == req.ActionCode);

        if (operation == null)
            throw new Exception($"Invalid action code: {req.ActionCode}");

        var result = operation.Calculate(req.A, req.B);

        _log.Log($"{DateTime.Now} | {operation.Name} | A:{req.A} B:{req.B} Result:{result}");

        return new ProbabilityResult
        {
            Result = result,
            Operation = operation.Name
        };
    }
}
