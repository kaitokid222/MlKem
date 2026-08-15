namespace MlKemNet.Internal;

internal static class BitCodec
{
    /// <summary>
    /// Converts a bit array to a byte array as specified by FIPS 203,
    /// Section 4.2.1, Algorithm 3.
    /// </summary>
    /// <param name="bits">The bits to convert.</param>
    /// <returns>The encoded bytes.</returns>
    internal static byte[] BitsToBytes(ReadOnlySpan<byte> bits)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a byte array to a bit array as specified by FIPS 203,
    /// Section 4.2.1, Algorithm 4.
    /// </summary>
    /// <param name="bytes">The bytes to convert.</param>
    /// <returns>The decoded bits.</returns>
    internal static byte[] BytesToBits(ReadOnlySpan<byte> bytes)
    {
        throw new NotImplementedException();
    }
}

