namespace MlKemNet.Internal;

internal static class Compression
{
    /// <summary>
    /// Compresses a polynomial according to FIPS 203, Section 4.2.1.
    /// </summary>
    /// <param name="polynomial">The polynomial to compress.</param>
    /// <param name="bitsPerCoefficient">The compression parameter d.</param>
    /// <returns>The compressed polynomial.</returns>
    internal static Polynomial Compress(
        Polynomial polynomial,
        int bitsPerCoefficient)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Decompresses a polynomial according to FIPS 203, Section 4.2.1.
    /// </summary>
    /// <param name="polynomial">The polynomial to decompress.</param>
    /// <param name="bitsPerCoefficient">The decompression parameter d.</param>
    /// <returns>The decompressed polynomial.</returns>
    internal static Polynomial Decompress(
        Polynomial polynomial,
        int bitsPerCoefficient)
    {
        throw new NotImplementedException();
    }
}

