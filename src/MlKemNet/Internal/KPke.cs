namespace MlKemNet.Internal;

internal static class KPke
{
    /// <summary>
    /// Generates a K-PKE key pair as specified by FIPS 203, Section 5.1,
    /// Algorithm 13.
    /// </summary>
    /// <param name="seed">The 32-byte input seed.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The K-PKE key pair.</returns>
    internal static PkeKeyPair GenerateKeyPair(
        ReadOnlySpan<byte> seed,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Encrypts a message with K-PKE as specified by FIPS 203, Section 5.2,
    /// Algorithm 14.
    /// </summary>
    /// <param name="encryptionKey">The encoded K-PKE encryption key.</param>
    /// <param name="message">The 32-byte message.</param>
    /// <param name="randomness">The 32-byte encryption randomness.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The K-PKE ciphertext.</returns>
    internal static byte[] Encrypt(
        ReadOnlySpan<byte> encryptionKey,
        ReadOnlySpan<byte> message,
        ReadOnlySpan<byte> randomness,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Decrypts a K-PKE ciphertext as specified by FIPS 203, Section 5.3,
    /// Algorithm 15.
    /// </summary>
    /// <param name="decryptionKey">The encoded K-PKE decryption key.</param>
    /// <param name="ciphertext">The K-PKE ciphertext.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The decrypted 32-byte message.</returns>
    internal static byte[] Decrypt(
        ReadOnlySpan<byte> decryptionKey,
        ReadOnlySpan<byte> ciphertext,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }
}

