using Xunit;

namespace MlKemNet.Tests.Acvp;

public sealed class AcvpTests
{
    [Fact(Skip = "No pinned NIST ACVP keyGen vectors are vendored yet.")]
    public void KeyGenerationVectors()
    {
    }

    [Fact(Skip = "No pinned NIST ACVP encapDecap vectors are vendored yet.")]
    public void EncapsulationAndDecapsulationVectors()
    {
    }

    [Fact(Skip = "No pinned NIST ACVP key-validation vectors are vendored yet.")]
    public void KeyValidationVectors()
    {
    }
}
