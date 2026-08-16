using Waher.Security.SHA3;

namespace MlKemNet.Fips202;

internal sealed class WaherShake128Context : IXofContext
{
    private readonly MemoryStream absorbedInput = new();
    private readonly SHAKE128 shake128 = new(0);
    private Keccak1600.Context? context;
    private bool disposed;

    public void Absorb(ReadOnlySpan<byte> input)
    {
        ThrowIfDisposed();

        if (context is not null)
        {
            throw new InvalidOperationException(
                "Input cannot be absorbed after squeezing has begun.");
        }

        absorbedInput.Write(input);
    }

    public void Squeeze(Span<byte> output)
    {
        ThrowIfDisposed();

        if (output.IsEmpty)
        {
            return;
        }

        if (context is null)
        {
            context = shake128.Absorb(absorbedInput.ToArray());
            absorbedInput.Dispose();
        }

        context.Squeeze(output.Length).AsSpan().CopyTo(output);
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        absorbedInput.Dispose();
        context = null;
        disposed = true;

        GC.SuppressFinalize(this);
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(disposed, this);
    }
}
