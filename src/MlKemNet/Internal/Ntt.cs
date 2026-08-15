namespace MlKemNet.Internal;

internal static class Ntt
{
    /// <summary>
    /// Applies the number-theoretic transform specified by FIPS 203,
    /// Section 4.3, Algorithm 9.
    /// </summary>
    /// <param name="polynomial">The polynomial to transform.</param>
    /// <returns>The NTT-domain representation.</returns>
    internal static NttPolynomial Forward(Polynomial polynomial)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies the inverse number-theoretic transform specified by FIPS 203,
    /// Section 4.3, Algorithm 10.
    /// </summary>
    /// <param name="polynomial">The NTT-domain polynomial to transform.</param>
    /// <returns>The ordinary polynomial representation.</returns>
    internal static Polynomial Inverse(NttPolynomial polynomial)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies two NTT-domain polynomials as specified by FIPS 203,
    /// Section 4.3.1, Algorithm 11.
    /// </summary>
    /// <param name="left">The left polynomial.</param>
    /// <param name="right">The right polynomial.</param>
    /// <returns>The NTT-domain product.</returns>
    internal static NttPolynomial Multiply(
        NttPolynomial left,
        NttPolynomial right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies one pair of NTT base-case polynomials as specified by
    /// FIPS 203, Section 4.3.1, Algorithm 12.
    /// </summary>
    /// <param name="a0">The first coefficient of the left operand.</param>
    /// <param name="a1">The second coefficient of the left operand.</param>
    /// <param name="b0">The first coefficient of the right operand.</param>
    /// <param name="b1">The second coefficient of the right operand.</param>
    /// <param name="gamma">The base-case root.</param>
    /// <returns>The two coefficients of the product.</returns>
    internal static (short First, short Second) BaseCaseMultiply(
        short a0,
        short a1,
        short b0,
        short b1,
        short gamma)
    {
        throw new NotImplementedException();
    }
}

