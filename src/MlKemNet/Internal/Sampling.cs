using MlKemNet.Fips202;

namespace MlKemNet.Internal;

internal static class Sampling
{
    /// <summary>
    /// Samples an NTT-domain polynomial as specified by FIPS 203,
    /// Section 4.2.2, Algorithm 7.
    /// </summary>
    /// <param name="bytes">The pseudorandom byte stream.</param>
    /// <param name="fips202">The FIPS 202 implementation.</param>
    /// <returns>The sampled NTT-domain polynomial.</returns>
    internal static NttPolynomial SampleNtt(
        ReadOnlySpan<byte> bytes,
        IFips202 fips202)
    {
        if (bytes.Length != 34)
        {
            throw new ArgumentException(
                "SampleNTT requires exactly 34 bytes.",
                nameof(bytes));
        }

        ArgumentNullException.ThrowIfNull(fips202);

        var polynomial = new NttPolynomial();

        using var xof = fips202.CreateShake128();

        xof.Absorb(bytes);

        Span<byte> buffer = stackalloc byte[3];

        var j = 0;

        while (j < Constants.N)
        {
            xof.Squeeze(buffer);

            var d1 =
                buffer[0] |
                ((buffer[1] & 0x0F) << 8);

            var d2 =
                (buffer[1] >> 4) |
                (buffer[2] << 4);

            if (d1 < Constants.Q)
            {
                polynomial.Coefficients[j++] = (short)d1;
            }

            if (d2 < Constants.Q && j < Constants.N)
            {
                polynomial.Coefficients[j++] = (short)d2;
            }
        }

        return polynomial;
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
        if (eta is not (2 or 3))
        {
            throw new ArgumentOutOfRangeException(
                nameof(eta),
                eta,
                "Eta must be either 2 or 3.");
        }

        var expectedLength = 64 * eta;

        if (bytes.Length != expectedLength)
        {
            throw new ArgumentException(
                $"SamplePolyCBD requires exactly {expectedLength} bytes for eta = {eta}.",
                nameof(bytes));
        }

        var bits = BitCodec.BytesToBits(bytes);
        var polynomial = new Polynomial();

        for (var i = 0; i < Constants.N; i++)
        {
            var x = 0;
            var y = 0;

            for (var j = 0; j < eta; j++)
            {
                x += bits[2 * i * eta + j];
                y += bits[2 * i * eta + eta + j];
            }

            polynomial.Coefficients[i] = (short)(x - y);
        }

        return polynomial;
    }
}

