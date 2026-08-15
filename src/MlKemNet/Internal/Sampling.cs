namespace MlKemNet.Internal;

internal static class Sampling
{
    /// <summary>
    /// Samples an NTT-domain polynomial as specified by FIPS 203,
    /// Section 4.2.2, Algorithm 7.
    /// </summary>
    /// <param name="bytes">The pseudorandom byte stream.</param>
    /// <returns>The sampled NTT-domain polynomial.</returns>
    internal static NttPolynomial SampleNtt(ReadOnlySpan<byte> bytes)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Samples a polynomial from a centered binomial distribution as
    /// specified by FIPS 203, Section 4.2.2, Algorithm 8.
    /// </summary>
    /// <param name="bytes">The pseudorandom input bytes.</param>
    /// <param name="eta">The distribution parameter eta.</param>
    /// <returns>The sampled polynomial.</returns>
    internal static Polynomial SamplePolynomialCbd(
        ReadOnlySpan<byte> bytes,
        int eta)
    {
        throw new NotImplementedException();
    }
}

