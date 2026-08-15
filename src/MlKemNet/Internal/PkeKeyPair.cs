namespace MlKemNet.Internal;

internal sealed record PkeKeyPair(
    byte[] EncryptionKey,
    byte[] DecryptionKey);

