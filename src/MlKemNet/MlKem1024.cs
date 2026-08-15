using MlKemNet.Models;

namespace MlKemNet;

/// <summary>
/// Provides the public ML-KEM-1024 operation stubs defined by FIPS 203,
/// Sections 7.1 through 7.3, Algorithms 19 through 21.
/// </summary>
public sealed class MlKem1024 : IKem
{
    /// <summary>
    /// Generates an ML-KEM-1024 key pair as specified by FIPS 203,
    /// Section 7.1, Algorithm 19.
    /// </summary>
    /// <returns>The generated key pair.</returns>
    public KeyPair GenerateKeyPair()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Encapsulates with ML-KEM-1024 as specified by FIPS 203, Section 7.2,
    /// Algorithm 20.
    /// </summary>
    /// <param name="encapsulationKey">The encoded encapsulation key.</param>
    /// <returns>The ciphertext and shared secret key.</returns>
    public EncapsulationResult Encapsulate(ReadOnlySpan<byte> encapsulationKey)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Decapsulates with ML-KEM-1024 as specified by FIPS 203, Section 7.3,
    /// Algorithm 21.
    /// </summary>
    /// <param name="decapsulationKey">The encoded decapsulation key.</param>
    /// <param name="ciphertext">The ciphertext to decapsulate.</param>
    /// <returns>The shared secret key.</returns>
    public byte[] Decapsulate(
        ReadOnlySpan<byte> decapsulationKey,
        ReadOnlySpan<byte> ciphertext)
    {
        throw new NotImplementedException();
    }
}
