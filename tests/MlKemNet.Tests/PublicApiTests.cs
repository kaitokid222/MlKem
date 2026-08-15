using System.Reflection;
using MlKemNet.Models;
using Xunit;

namespace MlKemNet.Tests;

public sealed class PublicApiTests
{
    [Theory]
    [InlineData(typeof(MlKem512))]
    [InlineData(typeof(MlKem768))]
    [InlineData(typeof(MlKem1024))]
    public void KemTypesAreSealedParameterlessImplementations(Type kemType)
    {
        Assert.True(kemType.IsSealed);
        Assert.Contains(typeof(IKem), kemType.GetInterfaces());

        ConstructorInfo? constructor = kemType.GetConstructor(Type.EmptyTypes);

        Assert.NotNull(constructor);
        Assert.NotNull(Activator.CreateInstance(kemType));
    }

    [Fact]
    public void KemInterfaceHasTheExpectedOperationShape()
    {
        MethodInfo[] methods = typeof(IKem).GetMethods();

        Assert.Equal(3, methods.Length);
        AssertMethod(
            methods,
            nameof(IKem.GenerateKeyPair),
            typeof(KeyPair));
        AssertMethod(
            methods,
            nameof(IKem.Encapsulate),
            typeof(EncapsulationResult),
            (typeof(ReadOnlySpan<byte>), "encapsulationKey"));
        AssertMethod(
            methods,
            nameof(IKem.Decapsulate),
            typeof(byte[]),
            (typeof(ReadOnlySpan<byte>), "decapsulationKey"),
            (typeof(ReadOnlySpan<byte>), "ciphertext"));
    }

    [Fact]
    public void PublicResultModelsUseFipsTerminology()
    {
        AssertProperties(
            typeof(KeyPair),
            (typeof(byte[]), nameof(KeyPair.EncapsulationKey)),
            (typeof(byte[]), nameof(KeyPair.DecapsulationKey)));
        AssertProperties(
            typeof(EncapsulationResult),
            (typeof(byte[]), nameof(EncapsulationResult.Ciphertext)),
            (typeof(byte[]), nameof(EncapsulationResult.SharedSecretKey)));
    }

    private static void AssertMethod(
        IEnumerable<MethodInfo> methods,
        string name,
        Type returnType,
        params (Type Type, string Name)[] expectedParameters)
    {
        MethodInfo method = Assert.Single(methods, candidate => candidate.Name == name);
        ParameterInfo[] actualParameters = method.GetParameters();

        Assert.Equal(returnType, method.ReturnType);
        Assert.Equal(expectedParameters.Length, actualParameters.Length);

        for (int index = 0; index < expectedParameters.Length; index++)
        {
            Assert.Equal(expectedParameters[index].Type, actualParameters[index].ParameterType);
            Assert.Equal(expectedParameters[index].Name, actualParameters[index].Name);
        }
    }

    private static void AssertProperties(
        Type type,
        params (Type Type, string Name)[] expectedProperties)
    {
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        Assert.Equal(expectedProperties.Length, properties.Length);

        foreach ((Type expectedType, string expectedName) in expectedProperties)
        {
            PropertyInfo? property = type.GetProperty(expectedName);

            Assert.NotNull(property);
            Assert.Equal(expectedType, property.PropertyType);
        }
    }
}

