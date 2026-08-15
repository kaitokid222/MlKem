using MlKemNet.Internal;
using Xunit;

namespace MlKemNet.Tests.Internal;

public sealed class ParameterSetTests
{
    [Fact]
    public void SharedConstantsMatchFips203()
    {
        Assert.Equal(256, Constants.N);
        Assert.Equal(3329, Constants.Q);
        Assert.Equal(32, Constants.SharedSecretKeySize);
    }

    [Fact]
    public void MlKem512ParametersMatchFips203()
    {
        AssertParameterSet(
            MlKemParameterSets.MlKem512,
            "ML-KEM-512",
            moduleRank: 2,
            eta1: 3,
            eta2: 2,
            du: 10,
            dv: 4,
            encapsulationKeySize: 800,
            decapsulationKeySize: 1632,
            ciphertextSize: 768);
    }

    [Fact]
    public void MlKem768ParametersMatchFips203()
    {
        AssertParameterSet(
            MlKemParameterSets.MlKem768,
            "ML-KEM-768",
            moduleRank: 3,
            eta1: 2,
            eta2: 2,
            du: 10,
            dv: 4,
            encapsulationKeySize: 1184,
            decapsulationKeySize: 2400,
            ciphertextSize: 1088);
    }

    [Fact]
    public void MlKem1024ParametersMatchFips203()
    {
        AssertParameterSet(
            MlKemParameterSets.MlKem1024,
            "ML-KEM-1024",
            moduleRank: 4,
            eta1: 2,
            eta2: 2,
            du: 11,
            dv: 5,
            encapsulationKeySize: 1568,
            decapsulationKeySize: 3168,
            ciphertextSize: 1568);
    }

    private static void AssertParameterSet(
        MlKemParameters actual,
        string name,
        int moduleRank,
        int eta1,
        int eta2,
        int du,
        int dv,
        int encapsulationKeySize,
        int decapsulationKeySize,
        int ciphertextSize)
    {
        Assert.Equal(name, actual.Name);
        Assert.Equal(moduleRank, actual.ModuleRank);
        Assert.Equal(eta1, actual.Eta1);
        Assert.Equal(eta2, actual.Eta2);
        Assert.Equal(du, actual.Du);
        Assert.Equal(dv, actual.Dv);
        Assert.Equal(encapsulationKeySize, actual.EncapsulationKeySize);
        Assert.Equal(decapsulationKeySize, actual.DecapsulationKeySize);
        Assert.Equal(ciphertextSize, actual.CiphertextSize);
    }
}

