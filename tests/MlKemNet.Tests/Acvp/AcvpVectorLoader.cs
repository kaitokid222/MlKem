using System.Text.Json;

namespace MlKemNet.Tests.Acvp;

internal static class AcvpVectorLoader
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = false,
    };

    internal static AcvpVectorSet Load(string path)
    {
        using FileStream stream = File.OpenRead(path);

        return JsonSerializer.Deserialize<AcvpVectorSet>(stream, SerializerOptions)
            ?? throw new InvalidDataException("The ACVP vector set was empty.");
    }
}

