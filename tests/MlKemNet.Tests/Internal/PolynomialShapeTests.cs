using MlKemNet.Internal;
using Xunit;

namespace MlKemNet.Tests.Internal;

public sealed class PolynomialShapeTests
{
    [Fact]
    public void OrdinaryAndNttPolynomialsAreDistinctFixedSizeTypes()
    {
        Polynomial polynomial = new();
        NttPolynomial nttPolynomial = new();

        Assert.NotEqual(polynomial.GetType(), nttPolynomial.GetType());
        Assert.Equal(Constants.N, polynomial.Coefficients.Length);
        Assert.Equal(Constants.N, nttPolynomial.Coefficients.Length);
        Assert.IsType<short[]>(polynomial.Coefficients);
        Assert.IsType<short[]>(nttPolynomial.Coefficients);
    }
}

