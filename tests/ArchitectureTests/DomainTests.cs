using System.Reflection;
using System.Reflection.Emit;

namespace ArchitectureTests;

public class DomainTests
{
    private static Assembly DomainAssembly = Assembly.GetAssembly(typeof(Domain.Catalog.Types.Author));

    [Fact]
    public void DomainProject_ShouldNotHaveAnyDependencies()
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Assembly domainAssembly = Assembly.GetAssembly(typeof(Domain.Catalog.Types.Author));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        var result = Types
        .InAssembly(domainAssembly)
        .ShouldNot()
        .HaveDependencyOnAny()
        .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ClassesAndRecordsWhichAreNotAbstractOrInterfaces_ShouldBeSealed()
    {
        var result = Types
        .InAssembly(DomainAssembly)
        .That()
        .AreNotAbstract()
        .Or()
        .AreNotInterfaces()
        .Should()
        .BeSealed()
        .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
