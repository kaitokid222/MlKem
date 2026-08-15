using MlKemNet.Models;

namespace MlKemNet.Internal;

internal static class MlKemInternal
{
    /// <summary>
    /// Deterministically generates an ML-KEM key pair as specified by
    /// FIPS 203, Section 6.1, Algorithm 16.
    /// </summary>
    /// <param name="d">The K-PKE key-generation seed.</param>
    /// <param name="z">The implicit-rejection seed.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The generated ML-KEM key pair.</returns>
    internal static KeyPair GenerateKeyPair(
        ReadOnlySpan<byte> d,
        ReadOnlySpan<byte> z,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deterministically encapsulates a shared secret as specified by
    /// FIPS 203, Section 6.2, Algorithm 17.
    /// </summary>
    /// <param name="encapsulationKey">The encoded encapsulation key.</param>
    /// <param name="message">The 32-byte random message.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The ciphertext and shared secret key.</returns>
    internal static EncapsulationResult Encapsulate(
        ReadOnlySpan<byte> encapsulationKey,
        ReadOnlySpan<byte> message,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deterministically decapsulates a shared secret as specified by
    /// FIPS 203, Section 6.3, Algorithm 18.
    /// </summary>
    /// <param name="decapsulationKey">The encoded decapsulation key.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    /// <returns>The shared secret key.</returns>
    internal static byte[] Decapsulate(
        ReadOnlySpan<byte> decapsulationKey,
        ReadOnlySpan<byte> ciphertext,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }
}

