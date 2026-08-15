namespace MlKemNet.Internal;

internal static class HashFunctions
{
    /// <summary>
    /// Applies the H hash function specified by FIPS 203, Section 4.1.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <returns>The hash output.</returns>
    internal static byte[] H(ReadOnlySpan<byte> input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies the G hash function specified by FIPS 203, Section 4.1.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <returns>The hash output.</returns>
    internal static byte[] G(ReadOnlySpan<byte> input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies the J hash function specified by FIPS 203, Section 4.1.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <returns>The hash output.</returns>
    internal static byte[] J(ReadOnlySpan<byte> input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies the PRF function specified by FIPS 203, Section 4.1.
    /// </summary>
    /// <param name="seed">The seed bytes.</param>
    /// <param name="nonce">The nonce byte.</param>
    /// <param name="outputLength">The requested output length in bytes.</param>
    /// <returns>The pseudorandom output.</returns>
    internal static byte[] Prf(
        ReadOnlySpan<byte> seed,
        byte nonce,
        int outputLength)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies the XOF function specified by FIPS 203, Section 4.1.
    /// </summary>
    /// <param name="seed">The seed bytes.</param>
    /// <param name="firstIndex">The first matrix index.</param>
    /// <param name="secondIndex">The second matrix index.</param>
    /// <param name="outputLength">The requested output length in bytes.</param>
    /// <returns>The extendable output.</returns>
    internal static byte[] Xof(
        ReadOnlySpan<byte> seed,
        byte firstIndex,
        byte secondIndex,
        int outputLength)
    {
        throw new NotImplementedException();
    }
}

