
using System.Text.Json;



public class OperationProvider : IOperationProvider
{
    public List<OperationDefinition> GetOperations()
    {
        var json = File.ReadAllText("Config/operations.json");
        return JsonSerializer.Deserialize<List<OperationDefinition>>(json);
    }
}
