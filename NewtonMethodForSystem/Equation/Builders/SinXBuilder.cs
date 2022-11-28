using NewtonMethodForSystem.Equation.Functions;

namespace NewtonMethodForSystem.Equation.Builders;

public class SinXBuilder
{
    private double _frequency;
    private double _amplitude;

    public SinXBuilder Frequency(double frequency)
    {
        _frequency = frequency;
        return this;
    }
    public SinXBuilder Amplitude(double amplitude)
    {
        _amplitude = amplitude;
        return this;
    }

    public SinX Build()
    {
        return new SinX(_frequency, _amplitude);
    }

}