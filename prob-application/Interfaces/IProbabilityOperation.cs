

public interface IProbabilityOperation
{
    int Code { get; }
    string Name { get; }
    double Calculate(double a, double b);
}
