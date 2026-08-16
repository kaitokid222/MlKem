namespace MlKemNet.Internal;

internal static class ByteCodec
{
    /// <summary>
    /// Encodes a polynomial as specified by FIPS 203, Section 4.2.1,
    /// Algorithm 5.
    /// </summary>
    /// <param name="polynomial">The polynomial to encode.</param>
    /// <param name="bitsPerCoefficient">The encoding parameter d.</param>
    /// <returns>The encoded polynomial.</returns>
    internal static byte[] Encode(
        Polynomial polynomial,
        int bitsPerCoefficient)
    {
        ArgumentNullException.ThrowIfNull(polynomial);

        if (bitsPerCoefficient is < 1 or > 12)
        {
            throw new ArgumentOutOfRangeException(
                nameof(bitsPerCoefficient));
        }

        var bits = new byte[Constants.N * bitsPerCoefficient];

        for (var i = 0; i < Constants.N; i++)
        {
            var a = polynomial.Coefficients[i];

            for (var j = 0; j < bitsPerCoefficient; j++)
            {
                var bitIndex = i * bitsPerCoefficient + j;

                bits[bitIndex] = (byte)(a & 1);
                a = (short)((a - bits[bitIndex]) / 2);
            }
        }

        return BitCodec.BitsToBytes(bits);
    }

    /// <summary>
    /// Decodes a polynomial as specified by FIPS 203, Section 4.2.1,
    /// Algorithm 6.
    /// </summary>
    /// <param name="encoded">The encoded polynomial.</param>
    /// <param name="bitsPerCoefficient">The decoding parameter d.</param>
    /// <returns>The decoded polynomial.</returns>
    internal static Polynomial Decode(
        ReadOnlySpan<byte> encoded,
        int bitsPerCoefficient)
    {
        if (bitsPerCoefficient is < 1 or > 12)
        {
            throw new ArgumentOutOfRangeException(
                nameof(bitsPerCoefficient));
        }

        var expectedLength = Constants.N * bitsPerCoefficient / 8;

        if (encoded.Length != expectedLength)
        {
            throw new ArgumentException(
                $"The encoded polynomial must contain exactly {expectedLength} bytes.",
                nameof(encoded));
        }

        var bits = BitCodec.BytesToBits(encoded);
        var polynomial = new Polynomial();

        var modulus = bitsPerCoefficient == 12
            ? Constants.Q
            : 1 << bitsPerCoefficient;

        for (var i = 0; i < Constants.N; i++)
        {
            var coefficient = 0;

            for (var j = 0; j < bitsPerCoefficient; j++)
            {
                coefficient += bits[i * bitsPerCoefficient + j] << j;
            }

            polynomial.Coefficients[i] = (short)(coefficient % modulus);
        }

        return polynomial;
    }
}

