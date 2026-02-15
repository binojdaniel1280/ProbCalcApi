public class EitherOperation : IProbabilityOperation
{
    public int Code => 2;
    public string Name => "Either";

    public double Calculate(double a, double b)
    {
        return a + b - (a * b);
    }
}
