using MlKemNet.Fips202;
using Xunit;

namespace MlKemNet.Tests.Fips202;

// Official byte-oriented NIST CAVP response archives:
// https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Algorithm-Validation-Program/documents/sha3/sha-3bytetestvectors.zip
// SHA-256: cd07701af2e47f5cc889d642528b4bf11f8b6eb55797c7307a96828ed8d8fc8c
// https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Algorithm-Validation-Program/documents/sha3/shakebytetestvectors.zip
// SHA-256: debfebc3157b3ceea002b84ca38476420389a3bf7e97dc5f53ea4689a16de4c7
public sealed class Fips202ProviderTests
{
    private readonly Fips202Provider provider = new();

    [Theory]
    [InlineData("", "a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a")]
    [InlineData("e9", "f0d04dd1e6cfc29a4460d521796852f25d9ef8d28b44ee91ff5b759d72c1e6d6")]
    [InlineData("56ea14d7fcb0db748ff649aaa5d0afdc2357528a9aad6076d73b2805b53d89e73681abfad26bee6c0f3d20215295f354f538ae80990d2281be6de0f6919aa9eb048c26b524f4d91ca87b54c0c54aa9b54ad02171e8bf31e8d158a9f586e92ffce994ecce9a5185cc80364d50a6f7b94849a914242fcb73f33a86ecc83c3403630d20650ddb8cd9c4", "4beae3515ba35ec8cbd1d94567e22b0d7809c466abfbafe9610349597ba15b45")]
    public void Sha3_256_NistCavpVectors(
        string messageHex,
        string expectedHex)
    {
        var result = provider.Sha3_256(Convert.FromHexString(messageHex));

        Assert.Equal(Convert.FromHexString(expectedHex), result);
    }

    [Theory]
    [InlineData("", "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a615b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26")]
    [InlineData("e5", "150240baf95fb36f8ccb87a19a41767e7aed95125075a2b2dbba6e565e1ce8575f2b042b62e29a04e9440314a821c6224182964d8b557b16a492b3806f4c39c1")]
    [InlineData("0ce9f8c3a990c268f34efd9befdb0f7c4ef8466cfdb01171f8de70dc5fefa92acbe93d29e2ac1a5c2979129f1ab08c0e77de7924ddf68a209cdfa0adc62f85c18637d9c6b33f4ff8", "b018a20fcf831dde290e4fb18c56342efe138472cbe142da6b77eea4fce52588c04c808eb32912faa345245a850346faec46c3a16d39bd2e1ddb1816bc57d2da")]
    public void Sha3_512_NistCavpVectors(
        string messageHex,
        string expectedHex)
    {
        var result = provider.Sha3_512(Convert.FromHexString(messageHex));

        Assert.Equal(Convert.FromHexString(expectedHex), result);
    }

    [Theory]
    [InlineData("", "7f9c2ba4e88f827d616045507605853e")]
    [InlineData("d9e8", "c7211512340734235bb8d3c4651495aa")]
    [InlineData("5d9ff9fe63c328ddbe0c865ac6ba605c52a14ee8e4870ba320ce849283532f2551959e74cf1a54c8b30ed75dd92e076637e4ad5213b3574e73d6640bd6245bc121378174dccdaa769e6e4f2dc650e1166c775d0a982021c0b160fe9438098e86b6cdc786f2a6d1ef68751551f7e99773daa28598d9961002c0b47ab511c8707df69f9b32796b723bf7685251d2c0d08567ad4e8540ddcc1b8a1a01f6c92aaaadcaf42301d9e53463", "f50af2684408915871948779a14c147c")]
    [InlineData("d94be6703183babe2a30331b0028193c", "0583c92e58ec7df9365dfa9ae3fab8bab0ae1a85c24cc834751a39159fe17d77")]
    [InlineData("a8ded9816defca8327c194a48a88ae4e", "ed7397b2215c6c412bf444b1b96fc55c531aef025c6dd13fb4ab53fcc20c91917d82c8d6710a8d7b4c24d18b54150490e98ee01b4a4b9790d1878810a8392d3fa203b066327c0c67cace3a08c57d0d30b62ba43121d8d715637884f055c55ad6689692249885dce01c96979f1a2b309943e14abb0ba8e227bceb381667579e10694bd442b99064aa88501431")]
    public void Shake128_NistCavpVectors(
        string messageHex,
        string expectedHex)
    {
        var expected = Convert.FromHexString(expectedHex);
        var result = provider.Shake128(
            Convert.FromHexString(messageHex),
            expected.Length);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "46b9dd2b0ba88d13233b3feb743eeb243fcd52ea62b81b82b50c27646ed5762f")]
    [InlineData("0dc1", "8e2df9d379bb034aee064e965f960ebb418a9bb535025fb96427f678cf207877")]
    [InlineData("d8f12b97f81d47aebbfb7314ff04172cf2be71c3778e238bcccdeecb691fbd542b00e5b7b1a0abb507f107f781fea700ea7e375fdea9e029754a0ea62216774bda3c59e8783d022360fe9625621c0d93e27f7bc03632942150716f019d048a752ccc0f93139c55df0f4aaa066a0550cf22e8c54e47d0475ba56b9842a392ffbc6bd98f1e4b64abd1", "e2e1c432dd07c2ee89a78f31211c92eeb5306c4fa4db93c4e5cd43080d6079e4")]
    [InlineData("c61a9188812ae73994bc0d6d4021e31bf124dc72669749111232da7ac29e61c4", "23ce")]
    [InlineData("dc886df3f69c49513de3627e9481db5871e8ee88eb9f99611541930a8bc885e0", "00648afbc5e651649db1fd82936b00dbbc122fb4c877860d385c4950d56de7e096d613d7a3f27ed8f26334b0ccc1407b41dccb23dfaa529818d1125cd5348092524366b85fabb97c6cd1e6066f459bcc566da87ec9b7ba36792d118ac39a4ccef6192bbf3a54af18e57b0c146101f6aeaa822bc4b4c9708b09f0b3bab41bcce964d999d1107bd7c27af989ebe1e104a35478df362ec4c9628f5ea29cc1164b92960d42068a59b1ddcb8875722ed59df36ea654d97b6bf39e5075121ec93f8a8ea6ee5d923997ae8a9d4c315a3d074e3ff83dfa26490f0f5b00a3cc3f110f0f761eaac885a3d1eee302014191733bf77b4d58cca49258897d6460")]
    public void Shake256_NistCavpVectors(
        string messageHex,
        string expectedHex)
    {
        var expected = Convert.FromHexString(expectedHex);
        var result = provider.Shake256(
            Convert.FromHexString(messageHex),
            expected.Length);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shake128Context_NistCavpVector_SupportsChunkedCalls()
    {
        var expected = Convert.FromHexString(
            "c7211512340734235bb8d3c4651495aa");
        var result = new byte[expected.Length];

        using var context = provider.CreateShake128();

        context.Absorb([0xD9]);
        context.Absorb([0xE8]);
        context.Squeeze(result.AsSpan(0, 3));
        context.Squeeze(result.AsSpan(3, 5));
        context.Squeeze(result.AsSpan(8));

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shake128Context_ThreeByteSqueezes_ContinueAcrossRateBlocks()
    {
        var input = Convert.FromHexString(
            "a8ded9816defca8327c194a48a88ae4e");
        var expected = provider.Shake128(input, 400);
        var result = new byte[expected.Length];

        using var context = provider.CreateShake128();

        context.Absorb(input.AsSpan(0, 7));
        context.Absorb(input.AsSpan(7));

        for (var offset = 0; offset < result.Length; offset += 3)
        {
            var length = Math.Min(3, result.Length - offset);

            context.Squeeze(result.AsSpan(offset, length));
        }

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(268435456)]
    public void Shake_OutputLengthOutsideSupportedRange_Throws(
        int outputLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => provider.Shake128([], outputLength));
        Assert.Throws<ArgumentOutOfRangeException>(
            () => provider.Shake256([], outputLength));
    }

    [Fact]
    public void Shake128Context_AbsorbAfterSqueeze_Throws()
    {
        using var context = provider.CreateShake128();

        context.Absorb([0x00]);
        context.Squeeze(new byte[1]);

        Assert.Throws<InvalidOperationException>(
            () => context.Absorb([0x01]));
    }

    [Fact]
    public void Shake128Context_UseAfterDispose_Throws()
    {
        var context = provider.CreateShake128();

        context.Dispose();

        Assert.Throws<ObjectDisposedException>(
            () => context.Absorb([]));
        Assert.Throws<ObjectDisposedException>(
            () => context.Squeeze(new byte[1]));
    }
}
