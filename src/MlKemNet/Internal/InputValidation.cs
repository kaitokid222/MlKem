namespace MlKemNet.Internal;

internal static class InputValidation
{
    /// <summary>
    /// Performs the normative encapsulation-key checks required by
    /// FIPS 203, Section 7.2, Algorithm 20.
    /// </summary>
    /// <param name="encapsulationKey">The encoded encapsulation key.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    internal static void ValidateEncapsulationKey(
        ReadOnlySpan<byte> encapsulationKey,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Performs the normative decapsulation input checks required by
    /// FIPS 203, Section 7.3, Algorithm 21.
    /// </summary>
    /// <param name="decapsulationKey">The encoded decapsulation key.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="parameters">The selected ML-KEM parameter set.</param>
    internal static void ValidateDecapsulationInputs(
        ReadOnlySpan<byte> decapsulationKey,
        ReadOnlySpan<byte> ciphertext,
        MlKemParameters parameters)
    {
        throw new NotImplementedException();
    }
}

