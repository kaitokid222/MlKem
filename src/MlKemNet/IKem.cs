using MlKemNet.Models;

namespace MlKemNet;

/// <summary>
/// Defines the public operations of an ML-KEM parameter set.
/// </summary>
public interface IKem
{
    /// <summary>
    /// Generates an encapsulation and decapsulation key pair as specified by
    /// FIPS 203, Section 7.1, Algorithm 19.
    /// </summary>
    /// <returns>The generated key pair.</returns>
    KeyPair GenerateKeyPair();

    /// <summary>
    /// Encapsulates a shared secret as specified by FIPS 203, Section 7.2,
    /// Algorithm 20.
    /// </summary>
    /// <param name="encapsulationKey">The encoded encapsulation key.</param>
    /// <returns>The ciphertext and shared secret key.</returns>
    EncapsulationResult Encapsulate(ReadOnlySpan<byte> encapsulationKey);

    /// <summary>
    /// Decapsulates a shared secret as specified by FIPS 203, Section 7.3,
    /// Algorithm 21.
    /// </summary>
    /// <param name="decapsulationKey">The encoded decapsulation key.</param>
    /// <param name="ciphertext">The ciphertext to decapsulate.</param>
    /// <returns>The shared secret key.</returns>
    byte[] Decapsulate(
        ReadOnlySpan<byte> decapsulationKey,
        ReadOnlySpan<byte> ciphertext);
}

