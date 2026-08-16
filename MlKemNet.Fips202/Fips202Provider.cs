using Waher.Security.SHA3;

namespace MlKemNet.Fips202;

/// <summary>
/// Maps the FIPS 202 abstraction to Waher.Security.SHA3.
/// </summary>
public sealed class Fips202Provider : IFips202
{
    /// <inheritdoc />
    public byte[] Sha3_256(ReadOnlySpan<byte> input)
    {
        var sha3 = new SHA3_256();

        return sha3.ComputeVariable(input.ToArray());
    }

    /// <inheritdoc />
    public byte[] Sha3_512(ReadOnlySpan<byte> input)
    {
        var sha3 = new SHA3_512();

        return sha3.ComputeVariable(input.ToArray());
    }

    /// <inheritdoc />
    public byte[] Shake128(
        ReadOnlySpan<byte> input,
        int outputLength)
    {
        var outputLengthInBits = GetOutputLengthInBits(outputLength);
        var shake = new SHAKE128(outputLengthInBits);

        return shake.ComputeVariable(input.ToArray());
    }

    /// <inheritdoc />
    public byte[] Shake256(
        ReadOnlySpan<byte> input,
        int outputLength)
    {
        var outputLengthInBits = GetOutputLengthInBits(outputLength);
        var shake = new SHAKE256(outputLengthInBits);

        return shake.ComputeVariable(input.ToArray());
    }

    /// <inheritdoc />
    public IXofContext CreateShake128()
    {
        return new WaherShake128Context();
    }

    private static int GetOutputLengthInBits(int outputLength)
    {
        if (outputLength < 0 || outputLength > int.MaxValue / 8)
        {
            throw new ArgumentOutOfRangeException(
                nameof(outputLength),
                outputLength,
                $"The output length must be between 0 and {int.MaxValue / 8} bytes.");
        }

        return outputLength * 8;
    }
}
