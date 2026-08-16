namespace MlKemNet.Fips202;

/// <summary>
/// Represents an absorb-then-squeeze extendable-output context.
/// </summary>
public interface IXofContext : IDisposable
{
    /// <summary>
    /// Absorbs input before squeezing begins. This method may be called
    /// repeatedly until the first non-empty squeeze.
    /// </summary>
    /// <param name="input">The input bytes to absorb.</param>
    void Absorb(ReadOnlySpan<byte> input);

    /// <summary>
    /// Writes the next bytes from the extendable output. Repeated calls
    /// continue from the same state.
    /// </summary>
    /// <param name="output">The destination for the next output bytes.</param>
    void Squeeze(Span<byte> output);
}
