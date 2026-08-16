namespace MlKemNet.Fips202;

/// <summary>
/// Provides the FIPS 202 functions required by ML-KEM.
/// </summary>
public interface IFips202
{
    /// <summary>
    /// Computes SHA3-256.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <returns>The 32-byte digest.</returns>
    byte[] Sha3_256(ReadOnlySpan<byte> input);

    /// <summary>
    /// Computes SHA3-512.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <returns>The 64-byte digest.</returns>
    byte[] Sha3_512(ReadOnlySpan<byte> input);

    /// <summary>
    /// Computes SHAKE128 output.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <param name="outputLength">The requested output length in bytes.</param>
    /// <returns>The requested extendable output.</returns>
    byte[] Shake128(
        ReadOnlySpan<byte> input,
        int outputLength);

    /// <summary>
    /// Computes SHAKE256 output.
    /// </summary>
    /// <param name="input">The input bytes.</param>
    /// <param name="outputLength">The requested output length in bytes.</param>
    /// <returns>The requested extendable output.</returns>
    byte[] Shake256(
        ReadOnlySpan<byte> input,
        int outputLength);

    /// <summary>
    /// Creates an incremental SHAKE128 context.
    /// </summary>
    /// <returns>A new SHAKE128 context.</returns>
    IXofContext CreateShake128();
}
