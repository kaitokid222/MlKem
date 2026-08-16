using MlKemNet.Fips202;
using MlKemNet.Internal;
using Xunit;

namespace MlKemNet.Tests.Algorithms;

public sealed class SamplingTests
{
    [Fact]
    public void Algorithm07SampleNtt_WithFips202Provider_ReturnsExpectedShape()
    {
        var result = Sampling.SampleNtt(
            new byte[34],
            new Fips202Provider());

        Assert.Equal(Constants.N, result.Coefficients.Length);
        Assert.All(
            result.Coefficients,
            coefficient => Assert.InRange(
                coefficient,
                (short)0,
                (short)(Constants.Q - 1)));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Algorithm08SamplePolynomialCbd_ZeroInput_ReturnsZeroPolynomial(
        int eta)
    {
        var input = new byte[64 * eta];

        var result = Sampling.SamplePolynomialCbd(input, eta);

        Assert.Equal(Constants.N, result.Coefficients.Length);
        Assert.All(
            result.Coefficients,
            coefficient => Assert.Equal((short)0, coefficient));
    }

    [Theory]
    [InlineData(2, 0x03, 2)]
    [InlineData(3, 0x07, 3)]
    public void Algorithm08SamplePolynomialCbd_PositiveBoundaryBits_ReturnEta(
        int eta,
        byte firstByte,
        short expectedCoefficient)
    {
        var input = new byte[64 * eta];
        input[0] = firstByte;

        var result = Sampling.SamplePolynomialCbd(input, eta);

        Assert.Equal(expectedCoefficient, result.Coefficients[0]);
        Assert.All(
            result.Coefficients[1..],
            coefficient => Assert.Equal((short)0, coefficient));
    }

    [Theory]
    [InlineData(2, 0x0C, Constants.Q - 2)]
    [InlineData(3, 0x38, Constants.Q - 3)]
    public void Algorithm08SamplePolynomialCbd_NegativeBoundaryBits_AreCongruentModuloQ(
        int eta,
        byte firstByte,
        short expectedCoefficient)
    {
        var input = new byte[64 * eta];
        input[0] = firstByte;

        var result = Sampling.SamplePolynomialCbd(input, eta);

        Assert.Equal(
            expectedCoefficient,
            ReduceModuloQ(result.Coefficients[0]));
        Assert.All(
            result.Coefficients[1..],
            coefficient => Assert.Equal((short)0, coefficient));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Algorithm08SamplePolynomialCbd_AllOneBits_ReturnsZeroPolynomial(
        int eta)
    {
        var input = new byte[64 * eta];
        Array.Fill(input, byte.MaxValue);

        var result = Sampling.SamplePolynomialCbd(input, eta);

        Assert.All(
            result.Coefficients,
            coefficient => Assert.Equal((short)0, coefficient));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Algorithm08SamplePolynomialCbd_OutputUsesFipsCoefficientRange(
        int eta)
    {
        var input = new byte[64 * eta];

        for (var i = 0; i < input.Length; i++)
        {
            input[i] = (byte)i;
        }

        var result = Sampling.SamplePolynomialCbd(input, eta);

        Assert.All(
            result.Coefficients,
            coefficient =>
            {
                var reducedCoefficient = ReduceModuloQ(coefficient);

                Assert.True(
                    reducedCoefficient <= eta ||
                    reducedCoefficient >= Constants.Q - eta,
                    $"Coefficient {coefficient} is outside the FIPS 203 range for eta = {eta}.");
            });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4)]
    public void Algorithm08SamplePolynomialCbd_InvalidEta_Throws(int eta)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => Sampling.SamplePolynomialCbd([], eta));

        Assert.Equal("eta", exception.ParamName);
    }

    [Theory]
    [InlineData(2, 127)]
    [InlineData(2, 129)]
    [InlineData(3, 191)]
    [InlineData(3, 193)]
    public void Algorithm08SamplePolynomialCbd_WrongInputLength_Throws(
        int eta,
        int inputLength)
    {
        var input = new byte[inputLength];

        var exception = Assert.Throws<ArgumentException>(
            () => Sampling.SamplePolynomialCbd(input, eta));

        Assert.Equal("bytes", exception.ParamName);
    }

    private static short ReduceModuloQ(short coefficient)
    {
        return (short)(((coefficient % Constants.Q) + Constants.Q) % Constants.Q);
    }
}
