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

    [Fact]
    public void ByteEncode_TwoBitCoefficients_UsesFipsBitOrder()
    {
        Polynomial polynomial = new();

        for (var i = 0; i < Constants.N; i++)
        {
            polynomial.Coefficients[i] = (short)(i % 4);
        }

        var result = ByteCodec.Encode(polynomial, 2);
        var expected = new byte[64];
        Array.Fill(expected, (byte)0xE4);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ByteDecode_TwoBitCoefficients_UsesFipsBitOrder()
    {
        var encoded = new byte[64];
        Array.Fill(encoded, (byte)0xE4);

        var result = ByteCodec.Decode(encoded, 2);

        for (var i = 0; i < Constants.N; i++)
        {
            Assert.Equal((short)(i % 4), result.Coefficients[i]);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void ByteEncodeThenDecode_ValidPolynomial_PreservesCoefficients(
        int bitsPerCoefficient)
    {
        var modulus = bitsPerCoefficient == 12
            ? Constants.Q
            : 1 << bitsPerCoefficient;
        Polynomial polynomial = new();

        for (var i = 0; i < Constants.N; i++)
        {
            polynomial.Coefficients[i] =
                (short)(((i * 257) + 31) % modulus);
        }

        polynomial.Coefficients[^1] = (short)(modulus - 1);

        var encoded = ByteCodec.Encode(polynomial, bitsPerCoefficient);
        var result = ByteCodec.Decode(encoded, bitsPerCoefficient);

        Assert.Equal(32 * bitsPerCoefficient, encoded.Length);
        Assert.Equal(polynomial.Coefficients, result.Coefficients);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    public void ByteDecodeThenEncode_ForOneToOneRange_PreservesBytes(
        int bitsPerCoefficient)
    {
        var encoded = new byte[32 * bitsPerCoefficient];

        for (var i = 0; i < encoded.Length; i++)
        {
            encoded[i] = (byte)((i * 73) + 19);
        }

        var polynomial = ByteCodec.Decode(encoded, bitsPerCoefficient);
        var result = ByteCodec.Encode(polynomial, bitsPerCoefficient);

        Assert.Equal(encoded, result);
    }

    [Fact]
    public void ByteDecode_TwelveBitMaximum_ReducesModuloQ()
    {
        var encoded = new byte[32 * 12];
        Array.Fill(encoded, byte.MaxValue);

        var result = ByteCodec.Decode(encoded, 12);
        var expectedCoefficient = (short)(4095 % Constants.Q);

        Assert.All(
            result.Coefficients,
            coefficient => Assert.Equal(expectedCoefficient, coefficient));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    public void ByteEncode_BitsPerCoefficientOutsideFipsRange_Throws(
        int bitsPerCoefficient)
    {
        Polynomial polynomial = new();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => ByteCodec.Encode(polynomial, bitsPerCoefficient));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    public void ByteDecode_BitsPerCoefficientOutsideFipsRange_Throws(
        int bitsPerCoefficient)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => ByteCodec.Decode([], bitsPerCoefficient));
    }

    [Theory]
    [InlineData(1, 31)]
    [InlineData(1, 33)]
    [InlineData(12, 383)]
    [InlineData(12, 385)]
    public void ByteDecode_WrongEncodedLength_Throws(
        int bitsPerCoefficient,
        int encodedLength)
    {
        var encoded = new byte[encodedLength];

        Assert.Throws<ArgumentException>(
            () => ByteCodec.Decode(encoded, bitsPerCoefficient));
    }

    [Fact]
    public void ByteEncode_NullPolynomial_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => ByteCodec.Encode(null!, 1));
    }
}
