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
        if (bits.Length % 8 != 0)
        {
            throw new ArgumentException(
                "The bit array length must be a multiple of eight.",
                nameof(bits));
        }

        var bytes = new byte[bits.Length / 8];

        for (var i = 0; i < bits.Length; i++)
        {
            if (bits[i] > 1)
            {
                throw new ArgumentException(
                    "The bit array may only contain 0 or 1.",
                    nameof(bits));
            }

            bytes[i / 8] |= (byte)(bits[i] << (i % 8));
        }

        return bytes;
    }

    /// <summary>
    /// Converts a byte array to a bit array as specified by FIPS 203,
    /// Section 4.2.1, Algorithm 4.
    /// </summary>
    /// <param name="bytes">The bytes to convert.</param>
    /// <returns>The decoded bits.</returns>
    internal static byte[] BytesToBits(ReadOnlySpan<byte> bytes)
    {
        var bits = new byte[bytes.Length * 8];

        for (var i = 0; i < bytes.Length; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                bits[(8 * i) + j] = (byte)((bytes[i] >> j) & 1);
            }
        }

        return bits;
    }
}

