namespace MlKemNet.Models;

/// <summary>
/// Contains the outputs of an ML-KEM encapsulation operation.
/// </summary>
/// <param name="Ciphertext">The produced ciphertext.</param>
/// <param name="SharedSecretKey">The produced shared secret key.</param>
public sealed record EncapsulationResult(
    byte[] Ciphertext,
    byte[] SharedSecretKey);

