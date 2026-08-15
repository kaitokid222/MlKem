using MlKemNet.Internal;
using Xunit;

namespace MlKemNet.Tests.Algorithms;

public sealed class ConversionTests
{
    [Fact]
    public void BitsToBytes_FipsExample_Returns139()
    {
        byte[] bits =
        [
            1, 1, 0, 1, 0, 0, 0, 1
        ];

        var result = BitCodec.BitsToBytes(bits);

        Assert.Equal(139, result[0]);
    }

    [Fact]
    public void BytesToBits_FipsExample_ReturnsExpectedBits()
    {
        var result = BitCodec.BytesToBits([139]);

        byte[] expected =
        [
            1, 1, 0, 1, 0, 0, 0, 1
        ];

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Conversion_RoundTrip_PreservesBytes()
    {
        byte[] input =
        [
            0x00,
            0x01,
            0x7F,
            0x80,
            0xFF,
            0x8B
        ];

        var bits = BitCodec.BytesToBits(input);
        var result = BitCodec.BitsToBytes(bits);

        Assert.Equal(input, result);
    }

    [Fact(Skip = "MAGIC: FIPS 203 Algorithm 5 is not implemented.")]
    public void Algorithm05ByteEncode()
    {
    }

    [Fact(Skip = "MAGIC: FIPS 203 Algorithm 6 is not implemented.")]
    public void Algorithm06ByteDecode()
    {
    }
}
