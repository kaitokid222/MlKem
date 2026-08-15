namespace MlKemNet.Internal;

internal sealed record MlKemParameters(
    string Name,
    int ModuleRank,
    int Eta1,
    int Eta2,
    int Du,
    int Dv,
    int EncapsulationKeySize,
    int DecapsulationKeySize,
    int CiphertextSize);

