using System.Text.Json;
using System.Text.Json.Serialization;

namespace MlKemNet.Tests.Acvp;

internal sealed class AcvpVectorSet
{
    [JsonPropertyName("vsId")]
    public int VectorSetId { get; init; }

    [JsonPropertyName("algorithm")]
    public string Algorithm { get; init; } = string.Empty;

    [JsonPropertyName("mode")]
    public string Mode { get; init; } = string.Empty;

    [JsonPropertyName("revision")]
    public string Revision { get; init; } = string.Empty;

    [JsonPropertyName("isSample")]
    public bool IsSample { get; init; }

    [JsonPropertyName("testGroups")]
    public IReadOnlyList<AcvpTestGroup> TestGroups { get; init; } = [];
}

internal sealed class AcvpTestGroup
{
    [JsonPropertyName("tgId")]
    public int TestGroupId { get; init; }

    [JsonPropertyName("testType")]
    public string TestType { get; init; } = string.Empty;

    [JsonPropertyName("parameterSet")]
    public string ParameterSet { get; init; } = string.Empty;

    [JsonPropertyName("function")]
    public string Function { get; init; } = string.Empty;

    [JsonPropertyName("tests")]
    public IReadOnlyList<JsonElement> Tests { get; init; } = [];
}

