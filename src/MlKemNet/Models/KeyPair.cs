namespace MlKemNet.Models;

/// <summary>
/// Contains an ML-KEM encapsulation key and its corresponding decapsulation
/// key.
/// </summary>
/// <param name="EncapsulationKey">The encoded encapsulation key.</param>
/// <param name="DecapsulationKey">The encoded decapsulation key.</param>
public sealed record KeyPair(
    byte[] EncapsulationKey,
    byte[] DecapsulationKey);

