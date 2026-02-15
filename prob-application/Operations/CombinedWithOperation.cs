public class CombinedWithOperation : IProbabilityOperation
{
    public int Code => 1;
    public string Name => "CombinedWith";

    public double Calculate(double a, double b)
    {
        return a * b;
    }
}
