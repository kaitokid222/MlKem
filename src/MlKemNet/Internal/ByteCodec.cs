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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}

