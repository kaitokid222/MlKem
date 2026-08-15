namespace MlKemNet.Internal;

internal static class MlKemParameterSets
{
    internal static MlKemParameters MlKem512 { get; } = new(
        "ML-KEM-512",
        ModuleRank: 2,
        Eta1: 3,
        Eta2: 2,
        Du: 10,
        Dv: 4,
        EncapsulationKeySize: 800,
        DecapsulationKeySize: 1632,
        CiphertextSize: 768);

    internal static MlKemParameters MlKem768 { get; } = new(
        "ML-KEM-768",
        ModuleRank: 3,
        Eta1: 2,
        Eta2: 2,
        Du: 10,
        Dv: 4,
        EncapsulationKeySize: 1184,
        DecapsulationKeySize: 2400,
        CiphertextSize: 1088);

    internal static MlKemParameters MlKem1024 { get; } = new(
        "ML-KEM-1024",
        ModuleRank: 4,
        Eta1: 2,
        Eta2: 2,
        Du: 11,
        Dv: 5,
        EncapsulationKeySize: 1568,
        DecapsulationKeySize: 3168,
        CiphertextSize: 1568);
}

